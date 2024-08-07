﻿// SPDX-License-Identifier: MIT

using ByteSerialization;
using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Animations;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours;
using SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Materials;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Meshes;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Nodes;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Swe1rBehaviour = SWE1R.Assets.Blocks.ModelBlock.Behaviours.Behaviour;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rINode = SWE1R.Assets.Blocks.ModelBlock.Nodes.INode; // TODO: alias name should start with 'I'?
using Swe1rKeyframesOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.KeyframesOrInteger;
using Swe1rMaterial = SWE1R.Assets.Blocks.ModelBlock.Materials.Material;
using Swe1rMaterialTexture = SWE1R.Assets.Blocks.ModelBlock.Materials.MaterialTexture;
using Swe1rMaterialTextureChild = SWE1R.Assets.Blocks.ModelBlock.Materials.MaterialTextureChild;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rMeshMaterial = SWE1R.Assets.Blocks.ModelBlock.Materials.MeshMaterial;
using Swe1rMeshMaterialReference = SWE1R.Assets.Blocks.ModelBlock.Animations.MeshMaterialReference;
using Swe1rModelBlockItem = SWE1R.Assets.Blocks.ModelBlock.ModelBlockItem;
using Swe1rTargetOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.TargetOrInteger;
using Swe1rTriggerDescription = SWE1R.Assets.Blocks.ModelBlock.Behaviours.TriggerDescription;
using Swe1rVtx = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Vtx;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class ModelBlockItemExporter : BlockItemExporter<Swe1rModelBlockItem>
    {
        #region Fields

        private readonly BlockItemDumper _dumper = new UnityBlockItemDumper("out");
        private ByteSerializerContext _bitSerializerContext;

        #endregion

        #region Fields (mapping)

        private Dictionary<GameObject, Swe1rFlaggedNode> _flaggedNodeByPrefab = new();
        private Dictionary<MeshMaterialWrapper, Swe1rMeshMaterial> _meshMaterials = new();
        private Dictionary<MaterialTextureWrapper, Swe1rMaterialTexture> _materialTextures = new();
        private Dictionary<MaterialTextureChildWrapper, Swe1rMaterialTextureChild> _materialTextureChildren = new();
        private Dictionary<MaterialWrapper, Swe1rMaterial> _materials = new();
        private Dictionary<BehaviourWrapper, Swe1rBehaviour> _behaviours = new();
        private Dictionary<TriggerDescriptionWrapper, Swe1rTriggerDescription> _triggerDescriptions = new();
        private Dictionary<VtxWrapper, Swe1rVtx> _vtxs = new();
        private Dictionary<MeshMaterialReferenceWrapper, Swe1rMeshMaterialReference> _meshMaterialReferences = new();
        private Dictionary<KeyframesOrIntegerWrapper, Swe1rKeyframesOrInteger> _keyframesOrIntegers = new();
        private Dictionary<TargetOrIntegerWrapper, Swe1rTargetOrInteger> _targetOrIntegers = new();

        #endregion

        #region Properties (constructor)

        public ModelBlockItemWrapper ModelComponent { get; }
        public int ModelIndex { get; private set; }

        #endregion

        #region Properties (export)

        public Swe1rModelBlockItem ModelBlockItem { get; private set; }

        #endregion

        #region Constructor

        public ModelBlockItemExporter(ModelBlockItemWrapper modelComponent, int modelIndex)
        {
            ModelComponent = modelComponent;
            ModelIndex = modelIndex;
        }

        #endregion

        #region Methods (export)

        public void Export()
        {
            // export
            ModelBlockItem = ModelComponent.Export(this);

            // serialize
            ModelBlockItem.Save(out _bitSerializerContext);
            _dumper.DumpItem(ModelBlockItem, ModelIndex, _bitSerializerContext);
        }

        #endregion

        #region Methods (mapping)

        public Swe1rFlaggedNode GetFlaggedNode(GameObject gameObject)
        {
            GameObject prefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameObject);
            if (prefab == null)
                return null; // TODO: ever called?
            else if (_flaggedNodeByPrefab.TryGetValue(prefab, out Swe1rFlaggedNode swe1rFlaggedNode))
                return swe1rFlaggedNode;
            else
                return CreateFlaggedNode(prefab);
        }

        public Swe1rMeshMaterial GetMeshMaterial(MeshMaterialWrapper meshMaterialObject) =>
            meshMaterialObject == null ? null : _meshMaterials.GetOrCreate(meshMaterialObject, x => x.Export(this));

        public Swe1rMaterialTexture GetMaterialTexture(MaterialTextureWrapper materialTexureObject) =>
            _materialTextures.GetOrCreate(materialTexureObject, x => x.Export(this));

        public Swe1rMaterialTextureChild GetMaterialTextureChild(MaterialTextureChildWrapper materialTexureChildObject) =>
            _materialTextureChildren.GetOrCreate(materialTexureChildObject, x => x.Export(this));

        public Swe1rMaterial GetMaterial(MaterialWrapper materialObject) =>
            _materials.GetOrCreate(materialObject, x => x.Export(this));

        public Swe1rBehaviour GetBehaviour(BehaviourWrapper behaviourWrapper) =>
            _behaviours.GetOrCreate(behaviourWrapper, x => x.Export(this));

        public Swe1rTriggerDescription GetTriggerDescription(TriggerDescriptionWrapper triggerDescriptionWrapper) =>
            _triggerDescriptions.GetOrCreate(triggerDescriptionWrapper, x => x.Export(this));

        public Swe1rVtx GetVertex(VtxWrapper vtxWrapper) =>
            _vtxs.GetOrCreate(vtxWrapper, x => x.Export(this));

        public Swe1rMeshMaterialReference GetMeshMaterialReference(MeshMaterialReferenceWrapper materialReferenceObject) =>
            _meshMaterialReferences.GetOrCreate(materialReferenceObject, x => x.Export(this));

        public Swe1rTargetOrInteger GetTargetOrInteger(TargetOrIntegerWrapper targetOrInteger) =>
            _targetOrIntegers.GetOrCreate(targetOrInteger, x => x.Export(this));

        #endregion

        #region Methods (private)

        private Swe1rFlaggedNode CreateFlaggedNode(GameObject prefab)
        {
            var flaggedNodeComponent = prefab.GetComponent<IFlaggedNodeWrapper>();
            if (flaggedNodeComponent == null)
                return null;
            Swe1rFlaggedNode swe1rFlaggedNode = flaggedNodeComponent.Export(this);
            _flaggedNodeByPrefab[prefab] = swe1rFlaggedNode;

            List<GameObject> childGameObjects = prefab.GetChildren();
            if (childGameObjects.Count > 0)
            {
                swe1rFlaggedNode.Children = new List<Swe1rINode>();
                foreach (GameObject childGameObject in childGameObjects)
                {
                    GameObject childPrefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(childGameObject);

                    Swe1rMesh swe1rMesh = childPrefab.GetComponent<MeshWrapper>()?.Export(this);
                    if (swe1rMesh != null)
                        swe1rFlaggedNode.Children.Add(swe1rMesh);
                    else
                        swe1rFlaggedNode.Children.Add(GetFlaggedNode(childPrefab));
                }
            }
            swe1rFlaggedNode.UpdateChildrenCount();

            return swe1rFlaggedNode;
        }

        #endregion
    }
}

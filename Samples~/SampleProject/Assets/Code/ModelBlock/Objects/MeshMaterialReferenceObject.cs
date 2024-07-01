// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects;
using System;
using UnityEngine;
using Swe1rMeshMaterialReference = SWE1R.Assets.Blocks.ModelBlock.Animations.MeshMaterialReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class MeshMaterialReferenceObject : AbstractModelObject<Swe1rMeshMaterialReference>
    {
        #region Fields (serialized)

        [SerializeReference] public MeshMaterialScriptableObject meshMaterial;

        #endregion

        #region Methods

        public override void Import(Swe1rMeshMaterialReference source, ModelImporter importer) =>
            meshMaterial = importer.GetMeshMaterialScriptableObject(source.MeshMaterial);

        public override Swe1rMeshMaterialReference Export(ModelExporter exporter) =>
            new() {
                MeshMaterial = exporter.GetMeshMaterial(meshMaterial)
            };

        #endregion
    }
}

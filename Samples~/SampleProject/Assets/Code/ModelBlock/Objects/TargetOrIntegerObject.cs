// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes;
using SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects;
using System;
using UnityEngine;
using Swe1rTarget = SWE1R.Assets.Blocks.ModelBlock.Animations.Target;
using Swe1rTargetOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.TargetOrInteger;
using Swe1rTransformedWithPivotNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedWithPivotNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class TargetOrIntegerObject
    {
        #region Fields (serialized)

        [SerializeReference] public MeshMaterialReferenceObject meshMaterialReference;
        [SerializeReference] public MeshMaterialScriptableObject meshMaterial;
        [SerializeReference] public TransformedWithPivotNodeComponent transformedWithPivotNode;
        public int? integer;

        #endregion

        #region Constructor

        public TargetOrIntegerObject(Swe1rTargetOrInteger source, ModelImporter importer)
        {
            if (source.Integer.HasValue)
                integer = source.Integer.Value;
            else if (source.Target != null)
            {
                if (source.Target.MeshMaterialReference != null)
                    meshMaterialReference = 
                        importer.GetMeshMaterialReferenceObject(source.Target.MeshMaterialReference);
                else if (source.Target.MeshMaterial != null)
                    meshMaterial = 
                        importer.GetMeshMaterialScriptableObject(source.Target.MeshMaterial);
                else if (source.Target.TransformedWithPivotNode != null)
                    transformedWithPivotNode = 
                        importer.GetFlaggedNodeComponent<TransformedWithPivotNodeComponent>(source.Target.TransformedWithPivotNode);
            }
        }

        #endregion

        #region Methods (export)

        public Swe1rTargetOrInteger Export(ModelExporter exporter)
        {
            var result = new Swe1rTargetOrInteger();
            if (integer.HasValue)
                result.Integer = integer.Value;
            else
            {
                result.Target = new Swe1rTarget();
                if (meshMaterialReference != null)
                    result.Target.MeshMaterialReference =
                        exporter.GetMeshMaterialReference(meshMaterialReference);
                else if (meshMaterial != null)
                    result.Target.MeshMaterial =
                        exporter.GetMeshMaterial(meshMaterial);
                else if (transformedWithPivotNode != null)
                    result.Target.TransformedWithPivotNode = 
                        (Swe1rTransformedWithPivotNode)exporter.GetFlaggedNode(transformedWithPivotNode.gameObject);
            }
            return result;
        }

        #endregion
    }
}

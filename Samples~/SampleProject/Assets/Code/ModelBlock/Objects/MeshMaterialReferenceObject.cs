// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects;
using System;
using UnityEngine;
using Swe1rMeshMaterialReference = SWE1R.Assets.Blocks.ModelBlock.Animations.MeshMaterialReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class MeshMaterialReferenceObject
    {
        #region Fields (serialized)

        [SerializeReference] public MeshMaterialScriptableObject meshMaterial;

        #endregion

        #region Constructor

        public MeshMaterialReferenceObject(Swe1rMeshMaterialReference source, ModelImporter importer) =>
            meshMaterial = importer.GetMeshMaterialScriptableObject(source.MeshMaterial);

        #endregion

        #region Methods (export)

        public Swe1rMeshMaterialReference Export(ModelExporter exporter) =>
            new() {
                MeshMaterial = exporter.GetMeshMaterial(meshMaterial)
            };

        #endregion
    }
}

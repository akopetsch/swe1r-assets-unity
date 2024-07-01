// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Materials;
using System;
using UnityEngine;
using Swe1rMeshMaterialReference = SWE1R.Assets.Blocks.ModelBlock.Animations.MeshMaterialReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Animations
{
    [Serializable]
    public class MeshMaterialReferenceWrapper : ModelObjectWrapper<Swe1rMeshMaterialReference>
    {
        #region Fields

        [SerializeReference] public MeshMaterialWrapper meshMaterial;

        #endregion

        #region Methods

        public override void Import(Swe1rMeshMaterialReference source, ModelBlockItemImporter importer) =>
            meshMaterial = importer.GetMeshMaterialScriptableObject(source.MeshMaterial);

        public override Swe1rMeshMaterialReference Export(ModelBlockItemExporter exporter) =>
            new() {
                MeshMaterial = exporter.GetMeshMaterial(meshMaterial)
            };

        #endregion
    }
}

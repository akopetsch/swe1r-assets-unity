// SPDX-License-Identifier: MIT

using UnityEngine;
using Swe1rMeshMaterial = SWE1R.Assets.Blocks.ModelBlock.Materials.MeshMaterial;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Materials
{
    public class MeshMaterialWrapper : AbstractModelScriptableObject<Swe1rMeshMaterial>
    {
        #region Fields

        public int flags;
        public short textureOffsetX;
        public short textureOffsetY;
        public MaterialTextureWrapper materialTexture;
        [SerializeReference] public MaterialWrapper material;

        #endregion

        #region Methods

        public override void Import(Swe1rMeshMaterial source, ModelBlockItemImporter importer)
        {
            flags = source.Flags;
            textureOffsetX = source.TextureOffsetX;
            textureOffsetY = source.TextureOffsetY;
            if (source.MaterialTexture != null)
                materialTexture = importer.GetMaterialTextureScriptableObject(source.MaterialTexture);
            material = importer.GetMaterialPropertiesObject(source.Material);
        }

        public override Swe1rMeshMaterial Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rMeshMaterial();
            result.Flags = flags;
            result.TextureOffsetX = textureOffsetX;
            result.TextureOffsetY = textureOffsetY;
            if (materialTexture != null)
                result.MaterialTexture = exporter.GetMaterialTexture(materialTexture);
            result.Material = exporter.GetMaterial(material);
            return result;
        }

        #endregion
    }
}

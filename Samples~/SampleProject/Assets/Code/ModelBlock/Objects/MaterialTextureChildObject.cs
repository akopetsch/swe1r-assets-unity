// SPDX-License-Identifier: MIT

using System;
using Swe1rDimensionsBitmask = SWE1R.Assets.Blocks.ModelBlock.Meshes.DimensionsBitmask;
using Swe1rMaterialTextureChild = SWE1R.Assets.Blocks.ModelBlock.Materials.MaterialTextureChild;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class MaterialTextureChildObject
    {
        #region Fields (serialized)

        public byte byte_0;
        public byte byte_1;
        public byte byte_2;
        public Swe1rDimensionsBitmask dimensionsBitmask;
        public byte byte_4;
        public byte byte_5;
        public byte byte_6;
        public byte byte_7;
        public byte byte_c;
        public byte byte_d;
        public byte byte_e;
        public byte byte_f;

        #endregion

        #region Constructor

        public MaterialTextureChildObject(
            Swe1rMaterialTextureChild source, ModelImporter importer)
        {
            byte_0 = source.Byte_0;
            byte_1 = source.Byte_1;
            byte_2 = source.Byte_2;
            dimensionsBitmask = source.DimensionsBitmask;
            byte_4 = source.Byte_4;
            byte_5 = source.Byte_5;
            byte_6 = source.Byte_6;
            byte_7 = source.Byte_7;
            byte_c = source.Byte_c;
            byte_d = source.Byte_d;
            byte_e = source.Byte_e;
            byte_f = source.Byte_f;
        }

        #endregion

        #region Methods (export)

        public Swe1rMaterialTextureChild Export() =>
            new() {
                Byte_0 = byte_0,
                Byte_1 = byte_1,
                Byte_2 = byte_2,
                DimensionsBitmask = dimensionsBitmask,
                Byte_4 = byte_4,
                Byte_5 = byte_5,
                Byte_6 = byte_6,
                Byte_7 = byte_7,
                Byte_c = byte_c,
                Byte_d = byte_d,
                Byte_e = byte_e,
                Byte_f = byte_f,
            };

        #endregion
    }
}

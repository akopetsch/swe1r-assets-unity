// SPDX-License-Identifier: MIT

using System;
using Swe1rMaterial = SWE1R.Assets.Blocks.ModelBlock.Materials.Material;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Materials
{
    [Serializable]
    public class MaterialWrapper : AbstractModelObject<Swe1rMaterial>
    {
        #region Fields

        public int alphaBpp;
        public short word_4;

        public int[] ints_6;

        public int[] ints_e;

        public short unk_16;

        public int bitmask1;
        public int bitmask2;

        public short unk_20;

        public byte byte_22;
        public byte byte_23;
        public byte byte_24;
        public byte byte_25;

        public short unk_26;
        public short unk_28;
        public short unk_2a;
        public short unk_2c;

        public byte byte_2e;
        public byte byte_2f;
        public byte byte_30;
        public byte byte_31;

        public short unk_32;

        #endregion

        #region Methods

        public override void Import(Swe1rMaterial source, ModelBlockItemImporter importer)
        {
            alphaBpp = source.AlphaBpp;
            word_4 = source.Word_4;
            ints_6 = source.Ints_6;
            ints_e = source.Ints_e;
            unk_16 = source.Unk_16;
            bitmask1 = source.Bitmask1;
            bitmask2 = source.Bitmask2;
            unk_20 = source.Unk_20;
            byte_22 = source.Byte_22;
            byte_23 = source.Byte_23;
            byte_24 = source.Byte_24;
            byte_25 = source.Byte_25;
            unk_26 = source.Unk_26;
            unk_28 = source.Unk_28;
            unk_2a = source.Unk_2a;
            unk_2c = source.Unk_2c;
            byte_2e = source.Byte_2e;
            byte_2f = source.Byte_2f;
            byte_30 = source.Byte_30;
            byte_31 = source.Byte_31;
            unk_32 = source.Unk_32;
        }

        public override Swe1rMaterial Export(ModelBlockItemExporter modelExporter) =>
            new() {
                AlphaBpp = alphaBpp,
                Word_4 = word_4,
                Ints_6 = ints_6,
                Ints_e = ints_e,
                Unk_16 = unk_16,
                Bitmask1 = bitmask1,
                Bitmask2 = bitmask2,
                Unk_20 = unk_20,
                Byte_22 = byte_22,
                Byte_23 = byte_23,
                Byte_24 = byte_24,
                Byte_25 = byte_25,
                Unk_26 = unk_26,
                Unk_28 = unk_28,
                Unk_2a = unk_2a,
                Unk_2c = unk_2c,
                Byte_2e = byte_2e,
                Byte_2f = byte_2f,
                Byte_30 = byte_30,
                Byte_31 = byte_31,
                Unk_32 = unk_32,
            };

        #endregion
    }
}

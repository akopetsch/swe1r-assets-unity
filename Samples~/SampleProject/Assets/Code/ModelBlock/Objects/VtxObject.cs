// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System;
using Swe1rVtx = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Vtx;
using UnityColor32 = UnityEngine.Color32;
using UnityVectorInt = UnityEngine.Vector3Int;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class VtxObject : AbstractModelObject<Swe1rVtx>
    {
        #region Fields

        public UnityVectorInt position;
        public short u;
        public short v;
        public byte byte_C;
        public byte byte_D;
        public byte byte_E;
        public byte byte_F;

        public UnityColor32 color;

        #endregion

        #region Methods

        public override void Import(Swe1rVtx source, ModelBlockItemImporter importer)
        {
            position = source.Position.ToUnityVector3Int();
            u = source.U;
            v = source.V;
            byte_C = source.Byte_C;
            byte_D = source.Byte_D;
            byte_E = source.Byte_E;
            byte_F = source.Byte_F;

            color = source.Color.ToUnityColor32();
        }

        public override Swe1rVtx Export(ModelBlockItemExporter exporter) =>
            new()
            {
                Position = position.ToSwe1rVector3Int16(),
                U = u,
                V = v,
                Byte_C = byte_C,
                Byte_D = byte_D,
                Byte_E = byte_E,
                Byte_F = byte_F
            };

        #endregion
    }
}

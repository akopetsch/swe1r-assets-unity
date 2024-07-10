// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System;
using Swe1rVtx = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Vtx;
//using UnityColor32 = UnityEngine.Color32;
using UnityVectorInt = UnityEngine.Vector3Int;
using UnityVector2Int = UnityEngine.Vector2Int;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    [Serializable]
    public class VtxWrapper : ModelObjectWrapper<Swe1rVtx>
    {
        #region Fields

        public UnityVectorInt ob;
        public UnityVector2Int tc;
        public byte byte_C;
        public byte byte_D;
        public byte byte_E;
        public byte a;

        //public UnityColor32 color;

        #endregion

        #region Methods

        public override void Import(Swe1rVtx source, ModelBlockItemImporter importer)
        {
            ob = source.Ob.ToUnityVector3Int();
            tc = source.Tc.ToUnityVector2Int();
            byte_C = source.Byte_C;
            byte_D = source.Byte_D;
            byte_E = source.Byte_E;
            a = source.A;

            //color = source.Color.ToUnityColor32();
        }

        public override Swe1rVtx Export(ModelBlockItemExporter exporter) =>
            new()
            {
                Ob = ob.ToSwe1rVector3Int16(),
                Tc = tc.ToSwe1rVector2Int16(),
                Byte_C = byte_C,
                Byte_D = byte_D,
                Byte_E = byte_E,
                A = a
            };

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using System;
using Swe1rGsp2TrianglesCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp2TrianglesCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class Gsp2TrianglesCommandWrapper : GraphicsCommandWrapper<Swe1rGsp2TrianglesCommand>
    {
        #region Fields

        public byte v00;
        public byte v01;
        public byte v02;

        public byte v10;
        public byte v11;
        public byte v12;

        #endregion

        #region Methods

        public override void Import(Swe1rGsp2TrianglesCommand source, ModelBlockItemImporter importer)
        {
            v00 = source.V00;
            v01 = source.V01;
            v02 = source.V02;

            v10 = source.V10;
            v11 = source.V11;
            v12 = source.V12;
        }

        public override Swe1rGsp2TrianglesCommand Export(ModelBlockItemExporter exporter) =>
            new() {
                V00 = v00,
                V01 = v01,
                V02 = v02,

                V10 = v10,
                V11 = v11,
                V12 = v12,
            };

        #endregion
    }
}

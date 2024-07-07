// SPDX-License-Identifier: MIT

using System;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    [Serializable]
    public class GspVertexCommandWrapper : GraphicsCommandWrapper<Swe1rGspVertexCommand>
    {
        #region Fields

        public int i;
        public byte n;
        public byte v0;

        #endregion

        #region Methods

        public override void Import(Swe1rGspVertexCommand source, ModelBlockItemImporter importer)
        {
            i = source.I;
            n = source.N;
            v0 = (byte)source.V0;
        }

        public override Swe1rGspVertexCommand Export(ModelBlockItemExporter exporter) =>
            new()
            {
                VerticesStartIndex = i,
                N = n,
                V0 = v0,
            };

        #endregion
    }
}

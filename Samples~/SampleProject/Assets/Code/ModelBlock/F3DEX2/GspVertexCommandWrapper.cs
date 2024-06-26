﻿// SPDX-License-Identifier: MIT

using System;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    [Serializable]
    public class GspVertexCommandWrapper : GraphicsCommandWrapper<Swe1rGspVertexCommand>
    {
        #region Fields

        public int v;
        public byte n;
        public byte v0;

        #endregion

        #region Methods

        public override void Import(Swe1rGspVertexCommand source, ModelBlockItemImporter importer)
        {
            v = source.VerticesStartIndex;
            n = source.N;
            v0 = (byte)source.V0;
        }

        public override Swe1rGspVertexCommand Export(ModelBlockItemExporter exporter) =>
            new()
            {
                VerticesStartIndex = v,
                N = n,
                V0 = v0,
            };

        #endregion
    }
}

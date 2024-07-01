﻿// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.Linq;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class GspVertexCommandObject : GraphicsCommandObject<Swe1rGspVertexCommand>
    {
        #region Fields (serialized)

        public int v;
        public byte n;
        public byte v0;

        #endregion

        #region Properties

        public override IEnumerable<int> Indices => Enumerable.Empty<int>();

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rGspVertexCommand source, ModelImporter importer)
        {
            v = source.VerticesStartIndex;
            n = source.N;
            v0 = (byte)source.V0;
        }

        public override Swe1rGspVertexCommand Export(ModelExporter exporter) =>
            new()
            {
                VerticesStartIndex = v,
                N = n,
                V0 = v0,
            };

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;
using Swe1rGraphicsCommandByte = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommandByte;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    public class GraphicsCommandWrapperFactory
    {
        #region Fields

        private static readonly Dictionary<Swe1rGraphicsCommandByte, Type> typeByGraphicsCommandByte = new()
        {
            { Swe1rGraphicsCommandByte.G_VTX, typeof(GspVertexCommandWrapper) },
            { Swe1rGraphicsCommandByte.G_CULLDL, typeof(GspCullDisplayListCommandWrapper) },
            { Swe1rGraphicsCommandByte.G_TRI1, typeof(Gsp1TriangleCommandWrapper) },
            { Swe1rGraphicsCommandByte.G_TRI2, typeof(Gsp2TrianglesCommandWrapper) },
        };

        #endregion

        #region Members (singleton)

        public static GraphicsCommandWrapperFactory Instance { get; } = new GraphicsCommandWrapperFactory();
        private GraphicsCommandWrapperFactory() { }

        #endregion

        #region Methods

        public IGraphicsCommandWrapper CreateGraphicsCommandObject(Swe1rGraphicsCommand source, ModelBlockItemImporter importer)
        {
            var result = (IGraphicsCommandWrapper)Activator.CreateInstance(typeByGraphicsCommandByte[source.Byte]);
            result.Import(source, importer);
            return result;
        }

        #endregion
    }
}

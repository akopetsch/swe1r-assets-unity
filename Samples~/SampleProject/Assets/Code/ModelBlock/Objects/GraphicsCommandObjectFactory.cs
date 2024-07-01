// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;
using Swe1rGraphicsCommandByte = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommandByte;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    public class GraphicsCommandObjectFactory
    {
        #region Fields

        private static readonly Dictionary<Swe1rGraphicsCommandByte, Type> typeByGraphicsCommandByte = new()
        {
            { Swe1rGraphicsCommandByte.G_VTX, typeof(GspVertexCommandObject) },
            { Swe1rGraphicsCommandByte.G_CULLDL, typeof(GspCullDisplayListCommandObject) },
            { Swe1rGraphicsCommandByte.G_TRI1, typeof(Gsp1TriangleCommandObject) },
            { Swe1rGraphicsCommandByte.G_TRI2, typeof(Gsp2TrianglesCommandObject) },
        };

        #endregion

        #region Members (singleton)

        public static GraphicsCommandObjectFactory Instance { get; } = new GraphicsCommandObjectFactory();
        private GraphicsCommandObjectFactory() { }

        #endregion

        #region Methods

        public IGraphicsCommandObject CreateGraphicsCommandObject(Swe1rGraphicsCommand source, ModelImporter importer)
        {
            var result = (IGraphicsCommandObject)Activator.CreateInstance(typeByGraphicsCommandByte[source.Byte]);
            result.Import(source, importer);
            return result;
        }

        #endregion
    }
}

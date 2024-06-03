// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;
using Swe1rN64GspCommandByte = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommandByte;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    public class N64GspCommandObjectFactory
    {
        public static N64GspCommandObjectFactory Instance { get; } = new N64GspCommandObjectFactory();
        private N64GspCommandObjectFactory() { }

        private readonly
            Dictionary<Swe1rN64GspCommandByte, Type> typeByFlag =
            new Dictionary<Swe1rN64GspCommandByte, Type>()
        {
            { Swe1rN64GspCommandByte.G_VTX, typeof(N64GspVertexCommandObject) },
            { Swe1rN64GspCommandByte.G_CULLDL, typeof(N64GspCullDisplayListCommandObject) },
            { Swe1rN64GspCommandByte.G_TRI1, typeof(N64Gsp1TriangleCommandObject) },
            { Swe1rN64GspCommandByte.G_TRI2, typeof(N64Gsp2TrianglesCommandObject) },
        };

        public N64GspCommandObject CreateN64GspCommandObject(Swe1rN64GspCommand n64GspCommand, ModelImporter modelImporter)
        {
            var commandObject = (N64GspCommandObject)Activator.CreateInstance(typeByFlag[n64GspCommand.Byte]);
            commandObject.Import(n64GspCommand, modelImporter);
            return commandObject;
        }
    }
}

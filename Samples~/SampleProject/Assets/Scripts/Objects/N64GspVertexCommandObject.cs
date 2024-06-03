// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.Linq;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;
using Swe1rN64GspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspVertexCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class N64GspVertexCommandObject : N64GspCommandObject<Swe1rN64GspVertexCommand>
    {
        public short n;
        public byte v0PlusN;
        public int v0;

        public override IEnumerable<int> Indices => Enumerable.Empty<int>();

        public override void Import(Swe1rN64GspVertexCommand source, ModelImporter modelImporter)
        {
            n = source.N;
            v0PlusN = source.V0PlusN;
            v0 = source.V0;
        }

        public override Swe1rN64GspCommand Export(ModelExporter modelExporter, Swe1rMesh swe1rMesh)
        {
            var result = new Swe1rN64GspVertexCommand(
                n, v0PlusN, v0, swe1rMesh.Vertices);
            return result;
        }
    }
}

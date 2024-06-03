// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;
using Swe1rN64GspCullDisplayListCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCullDisplayListCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class N64GspCullDisplayListCommandObject : N64GspCommandObject<Swe1rN64GspCullDisplayListCommand>
    {
        public byte v0;
        public byte vN;

        public override IEnumerable<int> Indices { get { yield return vN; } }

        public override void Import(Swe1rN64GspCullDisplayListCommand source, ModelImporter modelImporter)
        {
            v0 = source.V0;
            vN = source.VN;
        }

        public override Swe1rN64GspCommand Export(ModelExporter modelExporter, Swe1rMesh swe1rMesh) =>
            new Swe1rN64GspCullDisplayListCommand() {
                V0 = v0,
                VN = vN,
            };
    }
}

// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rN64Gsp1TriangleCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64Gsp1TriangleCommand;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class N64Gsp1TriangleCommandObject : N64GspCommandObject<Swe1rN64Gsp1TriangleCommand>
    {
        public byte v0;
        public byte v1;
        public byte v2;

        public override IEnumerable<int> Indices
        {
            get
            {
                yield return v0;
                yield return v1;
                yield return v2;
            }
        }

        public override void Import(Swe1rN64Gsp1TriangleCommand source, ModelImporter modelImporter)
        {
            v0 = source.V0;
            v1 = source.V1;
            v2 = source.V2;
        }

        public override Swe1rN64GspCommand Export(ModelExporter modelExporter, Swe1rMesh swe1rMesh) =>
            new Swe1rN64Gsp1TriangleCommand() {
                V0 = v0,
                V1 = v1,
                V2 = v2,
            };
    }
}

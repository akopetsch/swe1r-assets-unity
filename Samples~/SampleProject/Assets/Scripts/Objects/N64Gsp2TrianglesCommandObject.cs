// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rN64Gsp2TrianglesCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64Gsp2TrianglesCommand;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class N64Gsp2TrianglesCommandObject : N64GspCommandObject<Swe1rN64Gsp2TrianglesCommand>
    {
        public byte v00;
        public byte v01;
        public byte v02;

        public byte v10;
        public byte v11;
        public byte v12;

        public override IEnumerable<int> Indices
        {
            get
            {
                yield return v00;
                yield return v01;
                yield return v02;

                yield return v10;
                yield return v11;
                yield return v12;
            }
        }

        public override void Import(Swe1rN64Gsp2TrianglesCommand source, ModelImporter modelImporter)
        {
            v00 = source.V00;
            v01 = source.V01;
            v02 = source.V02;

            v10 = source.V10;
            v11 = source.V11;
            v12 = source.V12;
        }

        public override Swe1rN64GspCommand Export(ModelExporter modelExporter, Swe1rMesh swe1rMesh) =>
            new Swe1rN64Gsp2TrianglesCommand() {
                V00 = v00,
                V01 = v01,
                V02 = v02,

                V10 = v10,
                V11 = v11,
                V12 = v12,
            };
    }
}

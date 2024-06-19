// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rGsp1TriangleCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp1TriangleCommand;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class Gsp1TriangleCommandObject : GraphicsCommandObject<Swe1rGsp1TriangleCommand>
    {
        #region Fields (serialized)

        public byte v0;
        public byte v1;
        public byte v2;

        #endregion

        #region Properties

        public override IEnumerable<int> Indices
        {
            get
            {
                yield return v0;
                yield return v1;
                yield return v2;
            }
        }

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rGsp1TriangleCommand source, ModelImporter importer)
        {
            v0 = source.V0;
            v1 = source.V1;
            v2 = source.V2;
        }

        public override Swe1rGraphicsCommand Export(ModelExporter exporter, Swe1rMesh swe1rMesh) =>
            new Swe1rGsp1TriangleCommand() {
                V0 = v0,
                V1 = v1,
                V2 = v2,
            };

        #endregion
    }
}

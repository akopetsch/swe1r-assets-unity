// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.Linq;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class GspVertexCommandObject : GraphicsCommandObject<Swe1rGspVertexCommand>
    {
        #region Fields (serialized)

        public short n;
        public byte v0PlusN;
        public int v0;

        #endregion

        #region Properties

        public override IEnumerable<int> Indices => Enumerable.Empty<int>();

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rGspVertexCommand source, ModelImporter importer)
        {
            n = source.N;
            v0PlusN = source.V0PlusN;
            v0 = source.V0;
        }

        public override Swe1rGraphicsCommand Export(ModelExporter exporter, Swe1rMesh swe1rMesh)
        {
            var result = new Swe1rGspVertexCommand(
                n, v0PlusN, v0, swe1rMesh.Vertices);
            return result;
        }

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;
using Swe1rGsp2TrianglesCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp2TrianglesCommand;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class Gsp2TrianglesCommandObject : GraphicsCommandObject<Swe1rGsp2TrianglesCommand>
    {
        #region Fields (serialized)

        public byte v00;
        public byte v01;
        public byte v02;

        public byte v10;
        public byte v11;
        public byte v12;

        #endregion

        #region Properties

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

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rGsp2TrianglesCommand source, ModelImporter importer)
        {
            v00 = source.V00;
            v01 = source.V01;
            v02 = source.V02;

            v10 = source.V10;
            v11 = source.V11;
            v12 = source.V12;
        }

        public override Swe1rGraphicsCommand Export(ModelExporter exporter, Swe1rMesh swe1rMesh) =>
            new Swe1rGsp2TrianglesCommand() {
                V00 = v00,
                V01 = v01,
                V02 = v02,

                V10 = v10,
                V11 = v11,
                V12 = v12,
            };

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using System;
using Swe1rGsp1TriangleCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp1TriangleCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class Gsp1TriangleCommandObject : GraphicsCommandObject<Swe1rGsp1TriangleCommand>
    {
        #region Fields

        public byte v0;
        public byte v1;
        public byte v2;

        #endregion

        #region Methods

        public override void Import(Swe1rGsp1TriangleCommand source, ModelImporter importer)
        {
            v0 = source.V0;
            v1 = source.V1;
            v2 = source.V2;
        }

        public override Swe1rGsp1TriangleCommand Export(ModelExporter exporter) =>
            new() {
                V0 = v0,
                V1 = v1,
                V2 = v2,
            };

        #endregion
    }
}

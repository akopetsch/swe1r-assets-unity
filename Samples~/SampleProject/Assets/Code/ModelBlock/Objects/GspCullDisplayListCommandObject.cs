// SPDX-License-Identifier: MIT

using System;
using Swe1rGspCullDisplayListCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspCullDisplayListCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class GspCullDisplayListCommandObject : GraphicsCommandObject<Swe1rGspCullDisplayListCommand>
    {
        #region Fields

        public byte v0;
        public byte vN;

        #endregion

        #region Methods

        public override void Import(Swe1rGspCullDisplayListCommand source, ModelBlockItemImporter importer)
        {
            v0 = source.V0;
            vN = source.VN;
        }

        public override Swe1rGspCullDisplayListCommand Export(ModelBlockItemExporter exporter) =>
            new() {
                V0 = v0,
                VN = vN,
            };

        #endregion
    }
}

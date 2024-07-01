﻿// SPDX-License-Identifier: MIT

using System;
using Swe1rGspCullDisplayListCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspCullDisplayListCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class GspCullDisplayListCommandObject : GraphicsCommandObject<Swe1rGspCullDisplayListCommand>
    {
        #region Fields (serialized)

        public byte v0;
        public byte vN;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rGspCullDisplayListCommand source, ModelImporter importer)
        {
            v0 = source.V0;
            vN = source.VN;
        }

        public override Swe1rGspCullDisplayListCommand Export(ModelExporter exporter) =>
            new() {
                V0 = v0,
                VN = vN,
            };

        #endregion
    }
}

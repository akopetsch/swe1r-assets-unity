// SPDX-License-Identifier: MIT

using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    public interface IGraphicsCommandObject
    {
        public abstract IEnumerable<int> Indices { get; }

        public abstract void Import(Swe1rGraphicsCommand source, ModelImporter importer);
        public abstract Swe1rGraphicsCommand Export(ModelExporter exporter);
    }
}

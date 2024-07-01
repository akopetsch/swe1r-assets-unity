// SPDX-License-Identifier: MIT

using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    public interface IGraphicsCommandWrapper
    {
        public abstract void Import(Swe1rGraphicsCommand source, ModelBlockItemImporter importer);
        public abstract Swe1rGraphicsCommand Export(ModelBlockItemExporter exporter);
    }
}

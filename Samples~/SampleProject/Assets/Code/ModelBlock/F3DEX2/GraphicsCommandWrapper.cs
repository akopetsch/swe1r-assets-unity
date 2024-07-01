// SPDX-License-Identifier: MIT

using System;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    [Serializable]
    public abstract class GraphicsCommandWrapper<T> : 
        AbstractModelObject<T>, IGraphicsCommandWrapper where T : Swe1rGraphicsCommand
    {
        #region Methods

        void IGraphicsCommandWrapper.Import(Swe1rGraphicsCommand source, ModelBlockItemImporter importer) =>
            Import((T)source, importer);

        Swe1rGraphicsCommand IGraphicsCommandWrapper.Export(ModelBlockItemExporter exporter) =>
            Export(exporter);

        #endregion
    }
}

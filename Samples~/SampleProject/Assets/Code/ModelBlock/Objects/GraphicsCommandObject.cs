// SPDX-License-Identifier: MIT

using System;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public abstract class GraphicsCommandObject<T> : 
        AbstractModelObject<T>, IGraphicsCommandObject where T : Swe1rGraphicsCommand
    {
        #region Methods

        void IGraphicsCommandObject.Import(Swe1rGraphicsCommand source, ModelBlockItemImporter importer) =>
            Import((T)source, importer);

        Swe1rGraphicsCommand IGraphicsCommandObject.Export(ModelBlockItemExporter exporter) =>
            Export(exporter);

        #endregion
    }
}

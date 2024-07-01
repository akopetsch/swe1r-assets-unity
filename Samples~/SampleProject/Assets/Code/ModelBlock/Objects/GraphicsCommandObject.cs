// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public abstract class GraphicsCommandObject<T> : 
        AbstractObject<T>, IGraphicsCommandObject where T : Swe1rGraphicsCommand
    {
        #region Properties

        public abstract IEnumerable<int> Indices { get; }

        IEnumerable<int> IGraphicsCommandObject.Indices => throw new NotImplementedException();

        #endregion

        #region Methods

        void IGraphicsCommandObject.Import(Swe1rGraphicsCommand source, ModelImporter importer) =>
            Import((T)source, importer);

        Swe1rGraphicsCommand IGraphicsCommandObject.Export(ModelExporter exporter) =>
            Export(exporter);

        #endregion
    }
}

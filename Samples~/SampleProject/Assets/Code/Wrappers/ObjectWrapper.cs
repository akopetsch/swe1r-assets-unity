// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity.Wrappers
{
    public abstract class ObjectWrapper<TSource, TImporter, TExporter> :
        IWrapper<TSource, TImporter, TExporter>
    {
        #region Methods

        public abstract void Import(TSource source, TImporter importer);

        public abstract TSource Export(TExporter exporter);

        #endregion
    }
}

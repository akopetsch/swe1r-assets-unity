// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity
{
    public abstract class AbstractObject<TSource, TImporter, TExporter>
    {
        #region Methods

        public abstract void Import(TSource source, TImporter importer);

        public abstract TSource Export(TExporter exporter);

        #endregion
    }
}

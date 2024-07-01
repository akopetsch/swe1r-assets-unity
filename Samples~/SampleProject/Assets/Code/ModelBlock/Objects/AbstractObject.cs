// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    public abstract class AbstractObject<T>
    {
        #region Methods

        public abstract void Import(T source, ModelImporter importer);
        public abstract T Export(ModelExporter exporter);

        #endregion
    }
}

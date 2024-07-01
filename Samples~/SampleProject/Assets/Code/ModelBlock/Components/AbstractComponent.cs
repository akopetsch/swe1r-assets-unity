// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public abstract class AbstractComponent<T> : MonoBehaviour
    {
        #region Methods

        public abstract void Import(T source, ModelImporter importer);

        public abstract T Export(ModelExporter exporter);

        #endregion
    }
}

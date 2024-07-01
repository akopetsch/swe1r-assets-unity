// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity
{
    public abstract class AbstractComponent<TSource, TImporter, TExporter> : MonoBehaviour
    {
        #region Methods

        public abstract void Import(TSource source, TImporter importer);

        public abstract TSource Export(TExporter exporter);

        #endregion
    }
}

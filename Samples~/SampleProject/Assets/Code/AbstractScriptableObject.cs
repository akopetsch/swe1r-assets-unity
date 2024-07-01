// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity
{
    public abstract class AbstractScriptableObject<TSource, TImporter, TExporter> : ScriptableObject
    {
        #region Methods

        public abstract void Import(TSource source, TImporter importer);

        public abstract TSource Export(TExporter exporter);

        #endregion
    }
}

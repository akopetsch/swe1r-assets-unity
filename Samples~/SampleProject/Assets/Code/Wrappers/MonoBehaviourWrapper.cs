// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Wrappers
{
    public abstract class MonoBehaviourWrapper<TSource, TImporter, TExporter> : 
        MonoBehaviour, IWrapper<TSource, TImporter, TExporter>
    {
        #region Methods

        public abstract void Import(TSource source, TImporter importer);

        public abstract TSource Export(TExporter exporter);

        #endregion
    }
}

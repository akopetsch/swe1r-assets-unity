// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects
{
    public abstract class AbstractScriptableObject<T> : ScriptableObject
    {
        #region Methods (import/export)

        public abstract void Import(T source, ModelImporter importer);
        public abstract T Export(ModelExporter exporter);

        #endregion
    }
}

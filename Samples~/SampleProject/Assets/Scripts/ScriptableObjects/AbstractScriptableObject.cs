// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ScriptableObjects
{
    public abstract class AbstractScriptableObject<T> : ScriptableObject
    {
        public abstract void Import(T source, ModelImporter importer);
        public abstract T Export(ModelExporter exporter);
    }
}

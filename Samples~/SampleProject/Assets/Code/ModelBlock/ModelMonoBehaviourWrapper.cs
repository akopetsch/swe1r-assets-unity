// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Wrappers;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public abstract class ModelMonoBehaviourWrapper<TSource> : 
        MonoBehaviourWrapper<TSource, ModelBlockItemImporter, ModelBlockItemExporter>
    {

    }
}

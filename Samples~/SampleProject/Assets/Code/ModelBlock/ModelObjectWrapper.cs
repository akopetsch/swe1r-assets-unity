﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Wrappers;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public abstract class ModelObjectWrapper<TSource> : 
        ObjectWrapper<TSource, ModelBlockItemImporter, ModelBlockItemExporter>
    {
        
    }
}

// SPDX-License-Identifier: GPL-2.0-only

using System;
using System.Collections.Generic;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> creator)
        {
            if (!dict.TryGetValue(key, out TValue val))
            {
                val = creator(key);
                dict.Add(key, val);
            }
            return val;
        }
    }
}

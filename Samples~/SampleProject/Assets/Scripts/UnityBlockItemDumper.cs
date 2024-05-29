// SPDX-License-Identifier: GPL-2.0-only

using System.IO;

namespace SWE1R.Assets.Blocks.Unity
{
    public class UnityBlockItemDumper : BlockItemDumper
    {
        public UnityBlockItemDumper(string suffix) : 
            base(Path.Combine("Temp", "dump"), suffix)
        { }
    }
}

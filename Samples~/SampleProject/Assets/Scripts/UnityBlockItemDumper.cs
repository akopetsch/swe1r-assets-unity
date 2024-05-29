// SPDX-License-Identifier: MIT

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

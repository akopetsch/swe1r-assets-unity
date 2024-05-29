// SPDX-License-Identifier: GPL-2.0-only

using System.IO;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity
{
    public class TestTextureHelper
    {
        public Texture2D LoadTexture()
        {
            var result = new Texture2D(512, 512);
            result.LoadImage(File.ReadAllBytes(Path.Combine("Assets", "Textures", "TestTexture.png")));
            return result;
        }
    }
}

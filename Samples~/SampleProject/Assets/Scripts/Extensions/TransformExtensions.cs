// SPDX-License-Identifier: GPL-2.0-only

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static  class TransformExtensions
    {
        public static void FromMatrix(this Transform transform, Matrix4x4 matrix)
        {
            transform.localScale = matrix.ExtractScale();
            transform.localRotation = matrix.ExtractRotation();
            transform.localPosition = matrix.ExtractPosition();
        }
    }
}

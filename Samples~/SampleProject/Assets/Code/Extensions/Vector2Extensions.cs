// SPDX-License-Identifier: MIT

using NumericsVector2 = System.Numerics.Vector2;
using Swe1rVector2Int16 = SWE1R.Assets.Blocks.Vectors.Vector2Int16;
using UnityVector2 = UnityEngine.Vector2;
using UnityVector2Int = UnityEngine.Vector2Int;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class Vector2Extensions
    {
        public static NumericsVector2 ToNumericsVector2(this UnityVector2 source) =>
            new(source.x, source.y);

        public static Swe1rVector2Int16 ToSwe1rVector2Int16(this UnityVector2Int source) =>
            new((short)source.x, (short)source.y);

        public static UnityVector2 ToUnityVector2(this NumericsVector2 source) =>
            new(source.X, source.Y);

        public static UnityVector2Int ToUnityVector2Int(this Swe1rVector2Int16 source) =>
            new(source.X, source.Y);
    }
}

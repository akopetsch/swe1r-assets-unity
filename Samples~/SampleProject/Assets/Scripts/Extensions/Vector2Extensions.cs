﻿// SPDX-License-Identifier: GPL-2.0-only

using NumericsVector2 = System.Numerics.Vector2;
using UnityVector2 = UnityEngine.Vector2;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class Vector2Extensions
    {
        public static UnityVector2 ToUnityVector2(this NumericsVector2 source) =>
            new UnityVector2(source.X, source.Y);

        public static NumericsVector2 ToNumericsVector2(this UnityVector2 source) =>
            new NumericsVector2(source.x, source.y);
    }
}

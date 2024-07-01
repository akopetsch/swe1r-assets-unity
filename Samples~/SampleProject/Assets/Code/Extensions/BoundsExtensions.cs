// SPDX-License-Identifier: MIT

using Swe1rBoundsSingle = SWE1R.Assets.Blocks.Vectors.Bounds3Single;
using UnityBounds = UnityEngine.Bounds;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class BoundsExtensions // TODO: remove unused
    {
        public static UnityBounds ToUnityBounds(this Swe1rBoundsSingle source)
        {
            UnityVector3 min = source.Min.ToUnityVector3();
            var size = new UnityVector3(
                source.Max.X - source.Min.X,
                source.Max.Y - source.Min.Y,
                source.Max.Z - source.Min.Z);
            return new UnityBounds(min, size);
        }

        public static Swe1rBoundsSingle ToSwe1rBoundsF(this UnityBounds source) =>
            new() {
                Min = source.min.ToSwe1rVector3Single(),
                Max = source.max.ToSwe1rVector3Single(),
            };
    }
}

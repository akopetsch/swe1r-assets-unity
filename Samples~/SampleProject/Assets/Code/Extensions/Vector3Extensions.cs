// SPDX-License-Identifier: MIT

using Swe1rVector3Float = SWE1R.Assets.Blocks.Vectors.Vector3Single;
using Swe1rVector3Int16 = SWE1R.Assets.Blocks.Vectors.Vector3Int16;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class Vector3Extensions
    {
        public static UnityVector3 ToUnityVector3(this Swe1rVector3Int16 source) =>
            new(source.X, source.Y, source.Z);

        public static UnityVector3 ToUnityVector3(this Swe1rVector3Float source) =>
            new(source.X, source.Y, source.Z);
        
        public static Swe1rVector3Int16 ToSwe1rVector3Int16(this UnityVector3 source) =>
            new((short)source.x, (short)source.y, (short)source.z);

        public static Swe1rVector3Float ToSwe1rVector3Single(this UnityVector3 source) =>
            new(source.x, source.y, source.z);
    }
}

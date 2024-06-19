﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Swe1rCollisionVertices = SWE1R.Assets.Blocks.ModelBlock.Meshes.CollisionVertices;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class CollisionVerticesObject
    {
        #region Fields

        public List<UnityVector3> shortVectors;
        public List<UnityVector3> floatVectors;
        public byte[] paddingGarbage;

        #endregion

        #region Properties

        public int Count => shortVectors.Count + floatVectors.Count;

        #endregion

        #region Constructor

        public CollisionVerticesObject(Swe1rCollisionVertices source)
        {
            shortVectors = source.ShortVectors?.Select(v => v.ToUnityVector3()).ToList();
            floatVectors = source.FloatVectors?.Select(v => v.ToUnityVector3()).ToList();
            paddingGarbage = source.PaddingGarbage;
        }

        #endregion

        #region Methods (export)

        public Swe1rCollisionVertices Export()
        {
            var result = new Swe1rCollisionVertices();
            if (shortVectors.Count > 0)
                result.ShortVectors = shortVectors.Select(v => v.ToSwe1rVector3Int16()).ToList();
            if (floatVectors.Count > 0)
                result.FloatVectors = floatVectors.Select(v => v.ToSwe1rVector3Single()).ToList();
            result.PaddingGarbage = paddingGarbage;
            return result;
        }

        #endregion
    }
}

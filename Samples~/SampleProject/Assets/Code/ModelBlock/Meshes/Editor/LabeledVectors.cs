﻿// SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Meshes.Editor
{
    public class LabeledVectors : List<LabeledVector>
    {
        #region Methods

        public void AddLabel(Vector3 vector, string label) =>
            Get(vector).AddLine(label);

        public LabeledVector Get(Vector3 vector)
        {
            LabeledVector lv = this.FirstOrDefault(x => x.Vector == vector);
            if (lv == null)
                Add(lv = new LabeledVector(vector));
            return lv;
        }

        #endregion
    }
}

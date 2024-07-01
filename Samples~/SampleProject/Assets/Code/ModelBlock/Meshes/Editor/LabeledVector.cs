// SPDX-License-Identifier: MIT

using System;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Meshes.Editor
{
    public class LabeledVector
    {
        #region Properties

        public Vector3 Vector { get; }
        public Color Color { get; set; }
        public string Text { get; private set; } = string.Empty;

        #endregion

        #region Constructor

        public LabeledVector(Vector3 vector) =>
            Vector = vector;

        #endregion

        #region Methods

        public void AddLine(string line) =>
            Text += Environment.NewLine + line;

        #endregion
    }
}

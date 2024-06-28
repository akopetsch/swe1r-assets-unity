// SPDX-License-Identifier: MIT

using System;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Meshes.Editor
{
    public class LabeledVector
    {
        public Vector3 Vector { get; }
        public Color Color { get; set; }
        public string Text { get; private set; } = string.Empty;

        public LabeledVector(Vector3 vector) =>
            Vector = vector;

        public void AddLine(string line) =>
            Text += Environment.NewLine + line;
    }
}

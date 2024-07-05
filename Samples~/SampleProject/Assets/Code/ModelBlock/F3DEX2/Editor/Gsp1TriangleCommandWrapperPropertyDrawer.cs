// SPDX-License-Identifier: MIT

using UnityEditor;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(Gsp1TriangleCommandWrapper))]
    public class Gsp1TriangleCommandWrapperPropertyDrawer : GraphicsCommandListWrapperPropertyDrawer<Gsp1TriangleCommandWrapper>
    {
        #region Properties

        protected override string MacroName =>
            "gSP1Triangle"; // TODO: string literal

        protected override string[] PropertyNames =>
            new string[]
            {
                nameof(Gsp1TriangleCommandWrapper.v0),
                nameof(Gsp1TriangleCommandWrapper.v1),
                nameof(Gsp1TriangleCommandWrapper.v2),
            };

        #endregion
    }
}

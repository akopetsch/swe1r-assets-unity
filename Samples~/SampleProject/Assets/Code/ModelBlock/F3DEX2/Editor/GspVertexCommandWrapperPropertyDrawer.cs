// SPDX-License-Identifier: MIT

using UnityEditor;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(GspVertexCommandWrapper))]
    public class GspVertexCommandWrapperPropertyDrawer : GraphicsCommandListWrapperPropertyDrawer<GspVertexCommandWrapper>
    {
        #region Properties

        protected override string MacroName =>
            "gSPVertex"; // TODO: string literal

        protected override string[] PropertyNames =>
            new string[]
            {
                // TODO: macro argument 'v'
                nameof(GspVertexCommandWrapper.n),
                nameof(GspVertexCommandWrapper.v0),
            };

        #endregion
    }
}

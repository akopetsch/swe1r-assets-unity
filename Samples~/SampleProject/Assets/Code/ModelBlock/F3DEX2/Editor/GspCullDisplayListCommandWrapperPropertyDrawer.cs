// SPDX-License-Identifier: MIT

using UnityEditor;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(GspCullDisplayListCommandWrapper))]
    public class GspCullDisplayListCommandWrapperPropertyDrawer : GraphicsCommandListWrapperPropertyDrawer<GspCullDisplayListCommandWrapper>
    {
        #region Properties

        protected override string MacroName =>
            "gSPCullDisplayList"; // TODO: string literal

        protected override string[] PropertyNames =>
            new string[]
            {
                nameof(GspCullDisplayListCommandWrapper.v0),
                nameof(GspCullDisplayListCommandWrapper.vN),
            };

        #endregion
    }
}

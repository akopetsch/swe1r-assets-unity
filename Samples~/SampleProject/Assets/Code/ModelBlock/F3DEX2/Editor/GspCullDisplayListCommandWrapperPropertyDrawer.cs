// SPDX-License-Identifier: MIT

using UnityEditor;
using Swe1rGspCullDisplayListCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspCullDisplayListCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(GspCullDisplayListCommandWrapper))]
    public class GspCullDisplayListCommandWrapperPropertyDrawer : 
        GraphicsCommandWrapperPropertyDrawer<Swe1rGspCullDisplayListCommand>
    {
        #region Properties

        protected override string[] PropertyNames =>
            new string[]
            {
                nameof(GspCullDisplayListCommandWrapper.v0),
                nameof(GspCullDisplayListCommandWrapper.vN),
            };

        #endregion
    }
}

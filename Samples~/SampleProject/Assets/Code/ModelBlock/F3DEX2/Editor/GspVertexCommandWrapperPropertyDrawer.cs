// SPDX-License-Identifier: MIT

using UnityEditor;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(GspVertexCommandWrapper))]
    public class GspVertexCommandWrapperPropertyDrawer : 
        GraphicsCommandWrapperPropertyDrawer<Swe1rGspVertexCommand>
    {
        #region Properties

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

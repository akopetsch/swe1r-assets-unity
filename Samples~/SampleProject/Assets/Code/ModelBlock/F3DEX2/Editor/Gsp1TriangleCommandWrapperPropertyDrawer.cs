// SPDX-License-Identifier: MIT

using UnityEditor;
using Swe1rGsp1TriangleCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp1TriangleCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(Gsp1TriangleCommandWrapper))]
    public class Gsp1TriangleCommandWrapperPropertyDrawer : 
        GraphicsCommandWrapperPropertyDrawer<Swe1rGsp1TriangleCommand>
    {
        #region Properties

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

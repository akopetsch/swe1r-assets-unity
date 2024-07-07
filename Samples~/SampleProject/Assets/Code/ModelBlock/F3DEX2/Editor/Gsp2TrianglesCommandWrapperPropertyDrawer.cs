// SPDX-License-Identifier: MIT

using UnityEditor;
using Swe1rGsp2TrianglesCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Gsp2TrianglesCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    [CustomPropertyDrawer(typeof(Gsp2TrianglesCommandWrapper))]
    public class Gsp2TrianglesCommandWrapperPropertyDrawer : 
        GraphicsCommandWrapperPropertyDrawer<Swe1rGsp2TrianglesCommand>
    {
        #region Properties

        protected override string[] PropertyNames =>
            new string[]
            {
                nameof(Gsp2TrianglesCommandWrapper.v00),
                nameof(Gsp2TrianglesCommandWrapper.v01),
                nameof(Gsp2TrianglesCommandWrapper.v02),
                nameof(Gsp2TrianglesCommandWrapper.v10),
                nameof(Gsp2TrianglesCommandWrapper.v11),
                nameof(Gsp2TrianglesCommandWrapper.v12),
            };

        #endregion
    }
}

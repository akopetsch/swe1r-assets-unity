// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class IntegerComponent : MonoBehaviour
    {
        #region Fields

        public int integer;

        #endregion

        #region Methods (import/export)

        public void Import(int integer)
        {
            gameObject.name = integer.ToString("x8");
            this.integer = integer;
        }

        public int Export() =>
            integer;

        #endregion
    }
}

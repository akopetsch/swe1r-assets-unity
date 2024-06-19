// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Components.Models
{
    public class NullComponent : MonoBehaviour
    {
        #region Methods (import)

        public void Import()
        {
            gameObject.name = "null";
            gameObject.SetActive(false);
        }

        #endregion
    }
}

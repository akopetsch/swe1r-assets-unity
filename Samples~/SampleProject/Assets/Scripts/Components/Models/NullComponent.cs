// SPDX-License-Identifier: GPL-2.0-only

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Components.Models
{
    public class NullComponent : MonoBehaviour
    {
        public void Import()
        {
            gameObject.name = "null";
            gameObject.SetActive(false);
        }
    }
}

// SPDX-License-Identifier: GPL-2.0-only

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Components.Models
{
    public class IntegerComponent : MonoBehaviour
    {
        public int integer;

        public void Import(int integer)
        {
            gameObject.name = integer.ToString("x8");
            this.integer = integer;
        }

        public int Export() =>
            integer;
    }
}

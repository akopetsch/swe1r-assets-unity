// SPDX-License-Identifier: MIT

using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Editor
{
    internal static class SelectionHelper
    {
        internal static T GetSelectedGameObjectComponent<T>() where T : Component
        {
            var gameObject = Selection.objects.SingleOrDefault() as GameObject;
            if (gameObject == null)
            {
                Debug.LogError($"Selection is not a single {nameof(GameObject)}.");
                return null;
            }

            var modelComponent = gameObject.GetComponent<T>();
            if (modelComponent == null)
            {
                Debug.LogError($"Selected {nameof(GameObject)} does not have a {typeof(T).Name}.");
                return null;
            }
            return modelComponent;
        }
    }
}

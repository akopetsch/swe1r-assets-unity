// SPDX-License-Identifier: MIT

using System.Collections.Generic;
using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Extensions
{
    public static class GameObjectExtensions
    {
        public static void SetParent(this GameObject go, GameObject parent) =>
            go.transform.SetParent(parent.transform, false);

        public static GameObject AddChild(this GameObject go, string name = null)
        {
            var child = name != null ?
                new GameObject(name) :
                new GameObject();
            child.SetParent(go);
            return child;
        }

        public static List<GameObject> GetChildren(this GameObject go)
        {
            var children = new List<GameObject>(go.transform.childCount);
            foreach (Transform transform in go.transform)
                children.Add(transform.gameObject);
            return children;
        }
    }
}

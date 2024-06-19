// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Nodes;
using System;
using System.Collections.Generic;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class FlaggedNodeComponentFactory
    {
        #region Members (singleton)

        public static FlaggedNodeComponentFactory Instance { get; } = new FlaggedNodeComponentFactory();
        private FlaggedNodeComponentFactory() { }

        #endregion

        #region Fields

        private static readonly Dictionary<NodeFlags, Type> componentTypeByNodeFlags = new()
        {
            { NodeFlags.BasicNode, typeof(BasicNodeComponent) },
            { NodeFlags.SelectorNode, typeof(SelectorNodeComponent) },
            { NodeFlags.LodSelectorNode, typeof(LodSelectorNodeComponent) },
            { NodeFlags.MeshGroupNode, typeof(MeshGroupNodeComponent) },
            { NodeFlags.TransformedNode, typeof(TransformedNodeComponent) },
            { NodeFlags.TransformedWithPivotNode, typeof(TransformedWithPivotNodeComponent) },
            { NodeFlags.TransformedComputedNode, typeof(TransformedComputedNodeComponent) },
        };

        #endregion

        #region Methods

        public Type GetComponentType(FlaggedNode node) =>
            componentTypeByNodeFlags[node.Flags];

        #endregion
    }
}

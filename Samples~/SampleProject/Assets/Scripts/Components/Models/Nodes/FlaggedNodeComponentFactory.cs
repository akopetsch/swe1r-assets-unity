// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Nodes;
using System;
using System.Collections.Generic;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class FlaggedNodeComponentFactory
    {
        public static FlaggedNodeComponentFactory Instance { get; } = new FlaggedNodeComponentFactory();
        private FlaggedNodeComponentFactory() { }

        private readonly
            Dictionary<NodeFlags, Type> componentTypeByNodeFlags =
            new Dictionary<NodeFlags, Type>()
        {
            { NodeFlags.BasicNode, typeof(BasicNodeComponent) },
            { NodeFlags.SelectorNode, typeof(SelectorNodeComponent) },
            { NodeFlags.LodSelectorNode, typeof(LodSelectorNodeComponent) },
            { NodeFlags.MeshGroupNode, typeof(MeshGroupNodeComponent) },
            { NodeFlags.TransformedNode, typeof(TransformedNodeComponent) },
            { NodeFlags.TransformedWithPivotNode, typeof(TransformedWithPivotNodeComponent) },
            { NodeFlags.TransformedComputedNode, typeof(TransformedComputedNodeComponent) },
        };

        public Type GetComponentType(FlaggedNode node) =>
            componentTypeByNodeFlags[node.Flags];
    }
}

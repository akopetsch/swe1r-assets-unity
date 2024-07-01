// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Nodes;
using System;
using System.Collections.Generic;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Nodes
{
    public class FlaggedNodeWrapperFactory
    {
        #region Members (singleton)

        public static FlaggedNodeWrapperFactory Instance { get; } = new FlaggedNodeWrapperFactory();
        private FlaggedNodeWrapperFactory() { }

        #endregion

        #region Fields

        private static readonly Dictionary<NodeFlags, Type> componentTypeByNodeFlags = new()
        {
            { NodeFlags.BasicNode, typeof(BasicNodeWrapper) },
            { NodeFlags.SelectorNode, typeof(SelectorNodeWrapper) },
            { NodeFlags.LodSelectorNode, typeof(LodSelectorNodeWrapper) },
            { NodeFlags.MeshGroupNode, typeof(MeshGroupNodeWrapper) },
            { NodeFlags.TransformedNode, typeof(TransformedNodeWrapper) },
            { NodeFlags.TransformedWithPivotNode, typeof(TransformedWithPivotNodeWrapper) },
            { NodeFlags.TransformedComputedNode, typeof(TransformedComputedNodeWrapper) },
        };

        #endregion

        #region Methods

        public Type GetComponentType(FlaggedNode node) =>
            componentTypeByNodeFlags[node.Flags];

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.SelectorNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class SelectorNodeComponent : FlaggedNodeComponent<Swe1rSelectorNode>
    {
        #region Fields

        public int selectionValue;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rSelectorNode source)
        {
            base.Import(source);
            selectionValue = source.SelectionValue;
        }

        public override Swe1rFlaggedNode Export(ModelExporter exporter)
        {
            var result = (Swe1rSelectorNode)base.Export(exporter);
            result.SelectionValue = selectionValue;
            return result;
        }

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.SelectorNode;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class SelectorNodeComponent : FlaggedNodeComponent<Swe1rSelectorNode>
    {
        public int selectionValue;

        public override void Import(Swe1rSelectorNode source)
        {
            base.Import(source);
            selectionValue = source.SelectionValue;
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rSelectorNode)base.Export(modelExporter);
            result.SelectionValue = selectionValue;
            return result;
        }
    }
}

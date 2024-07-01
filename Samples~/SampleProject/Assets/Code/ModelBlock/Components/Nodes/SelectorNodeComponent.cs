// SPDX-License-Identifier: MIT

using Swe1rSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.SelectorNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class SelectorNodeComponent : FlaggedNodeComponent<Swe1rSelectorNode>
    {
        #region Fields

        public int selectionValue;

        #endregion

        #region Methods

        public override void Import(Swe1rSelectorNode source, ModelBlockItemImporter importer)
        {
            base.Import(source, importer);
            selectionValue = source.SelectionValue;
        }

        public override Swe1rSelectorNode Export(ModelBlockItemExporter exporter)
        {
            var result = base.Export(exporter);
            result.SelectionValue = selectionValue;
            return result;
        }

        #endregion
    }
}

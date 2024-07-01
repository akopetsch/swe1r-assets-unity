// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes;
using Swe1rBasicNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.BasicNode;
using Swe1rTrakModel = SWE1R.Assets.Blocks.ModelBlock.Types.TrakModel;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public class TrakModelWrapper : ModelWrapper<Swe1rTrakModel>
    {
        #region Fields

        public BasicNodeWrapper node;

        #endregion

        #region Methods

        public override void Import(Swe1rTrakModel header, ModelBlockItemImporter importer)
        {
            base.Import(header, importer);
            node = (BasicNodeWrapper)importer.CreateFlaggedNodeGameObject(header.Node, gameObject);
        }

        public override Swe1rTrakModel Export(ModelBlockItemExporter exporter)
        {
            var model = base.Export(exporter);
            model.Node = (Swe1rBasicNode)exporter.GetFlaggedNode(node.gameObject);
            return model;
        }

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes;
using Swe1rBasicNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.BasicNode;
using Swe1rTrakModel = SWE1R.Assets.Blocks.ModelBlock.Types.TrakModel;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public class TrakModelComponent : ModelComponent<Swe1rTrakModel>
    {
        #region Fields

        public BasicNodeComponent node;

        #endregion

        #region Methods

        public override void Import(Swe1rTrakModel header, ModelImporter importer)
        {
            base.Import(header, importer);
            node = (BasicNodeComponent)importer.CreateFlaggedNodeGameObject(header.Node, gameObject);
        }

        public override Swe1rTrakModel Export(ModelExporter exporter)
        {
            var model = base.Export(exporter);
            model.Node = (Swe1rBasicNode)exporter.GetFlaggedNode(node.gameObject);
            return model;
        }

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Nodes;
using Swe1rBasicNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.BasicNode;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swe1rTrakModel = SWE1R.Assets.Blocks.ModelBlock.Types.TrakModel;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Types
{
    public class TrakModelComponent : ModelComponent<Swe1rTrakModel>
    {
        #region Fields

        public BasicNodeComponent node;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rTrakModel header, ModelImporter importer)
        {
            base.Import(header, importer);
            node = (BasicNodeComponent)importer.CreateFlaggedNodeGameObject(header.Node, gameObject);
        }

        public override Swe1rModel Export(ModelExporter exporter)
        {
            var model = (Swe1rTrakModel)base.Export(exporter);
            model.Node = (Swe1rBasicNode)exporter.GetFlaggedNode(node.gameObject);
            return model;
        }

        #endregion
    }
}

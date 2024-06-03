﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Nodes;
using Swe1rBasicNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.BasicNode;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swe1rTrakModel = SWE1R.Assets.Blocks.ModelBlock.Types.TrakModel;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Types
{
    public class TrakModelComponent : ModelComponent<Swe1rTrakModel>
    {
        public BasicNodeComponent node;

        public override void Import(Swe1rTrakModel header, ModelImporter modelImporter)
        {
            base.Import(header, modelImporter);
            node = (BasicNodeComponent)modelImporter.CreateFlaggedNodeGameObject(header.Node, gameObject);
        }

        public override Swe1rModel Export(ModelExporter modelExporter)
        {
            var model = (Swe1rTrakModel)base.Export(modelExporter);
            model.Node = (Swe1rBasicNode)modelExporter.GetFlaggedNode(node.gameObject);
            return model;
        }
    }
}

﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Nodes;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;
using Swe1rLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.LodSelectorNodeChildReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class LodSelectorNodeChildReferenceWrapper : ModelMonoBehaviourWrapper<Swe1rLodSelectorNodeChildReference>
    {
        #region Fields

        public LodSelectorNodeWrapper lodSelectorNode;
        public int index;

        #endregion

        #region Methods

        public override void Import(Swe1rLodSelectorNodeChildReference source, ModelBlockItemImporter importer)
        {
            lodSelectorNode = importer.GetFlaggedNodeComponent<LodSelectorNodeWrapper>(source.LodSelectorNode);
            index = source.Index;

            gameObject.name = $"{lodSelectorNode.gameObject.name} [{index}]";
        }

        public override Swe1rLodSelectorNodeChildReference Export(ModelBlockItemExporter exporter) =>
            new()
            {
                LodSelectorNode = (Swe1rLodSelectorNode)exporter.GetFlaggedNode(lodSelectorNode.gameObject),
                Index = index
            };

        #endregion
    }
}

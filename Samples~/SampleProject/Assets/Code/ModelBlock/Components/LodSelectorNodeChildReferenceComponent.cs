// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;
using Swe1rLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.LodSelectorNodeChildReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class LodSelectorNodeChildReferenceComponent : AbstractComponent<Swe1rLodSelectorNodeChildReference>
    {
        #region Fields

        public LodSelectorNodeComponent lodSelectorNode;
        public int index;

        #endregion

        #region Methods

        public override void Import(Swe1rLodSelectorNodeChildReference source, ModelImporter importer)
        {
            lodSelectorNode = importer.GetFlaggedNodeComponent<LodSelectorNodeComponent>(source.LodSelectorNode);
            index = source.Index;

            gameObject.name = $"{lodSelectorNode.gameObject.name} [{index}]";
        }

        public override Swe1rLodSelectorNodeChildReference Export(ModelExporter exporter) =>
            new()
            {
                LodSelectorNode = (Swe1rLodSelectorNode)exporter.GetFlaggedNode(lodSelectorNode.gameObject),
                Index = index
            };

        #endregion
    }
}

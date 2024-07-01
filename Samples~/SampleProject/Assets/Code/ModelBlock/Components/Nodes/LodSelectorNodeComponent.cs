// SPDX-License-Identifier: MIT

using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class LodSelectorNodeComponent : FlaggedNodeComponent<Swe1rLodSelectorNode>
    {
        #region Fields

        public float[] lodDistances;
        public int[] unk;

        #endregion

        #region Methods

        public override void Import(Swe1rLodSelectorNode source, ModelBlockItemImporter importer)
        {
            base.Import(source, importer);
            lodDistances = source.LodDistances;
            unk = source.Unk;
        }

        public override Swe1rLodSelectorNode Export(ModelBlockItemExporter exporter)
        {
            var result = base.Export(exporter);
            result.LodDistances = lodDistances;
            result.Unk = unk;
            return result;
        }

        #endregion
    }
}

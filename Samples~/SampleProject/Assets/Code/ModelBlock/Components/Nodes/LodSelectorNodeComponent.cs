// SPDX-License-Identifier: MIT

using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class LodSelectorNodeComponent : FlaggedNodeComponent<Swe1rLodSelectorNode>
    {
        #region Fields (serialized)

        public float[] lodDistances;
        public int[] unk;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rLodSelectorNode source)
        {
            base.Import(source);
            lodDistances = source.LodDistances;
            unk = source.Unk;
        }

        public override Swe1rFlaggedNode Export(ModelExporter exporter)
        {
            var result = (Swe1rLodSelectorNode)base.Export(exporter);
            result.LodDistances = lodDistances;
            result.Unk = unk;
            return result;
        }

        #endregion
    }
}

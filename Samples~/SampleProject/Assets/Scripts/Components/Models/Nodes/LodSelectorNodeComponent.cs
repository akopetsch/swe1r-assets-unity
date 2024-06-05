// SPDX-License-Identifier: MIT

using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class LodSelectorNodeComponent : FlaggedNodeComponent<Swe1rLodSelectorNode>
    {
        public float[] lodDistances;
        public int[] unk;

        public override void Import(Swe1rLodSelectorNode source)
        {
            base.Import(source);
            lodDistances = source.LodDistances;
            unk = source.Unk;
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rLodSelectorNode)base.Export(modelExporter);
            result.LodDistances = lodDistances;
            result.Unk = unk;
            return result;
        }
    }
}

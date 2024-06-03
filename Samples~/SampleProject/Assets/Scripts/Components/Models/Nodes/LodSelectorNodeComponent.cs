// SPDX-License-Identifier: MIT

using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class LodSelectorNodeComponent : FlaggedNodeComponent<Swe1rLodSelectorNode>
    {
        public float[] floats;
        public int[] ints;

        public override void Import(Swe1rLodSelectorNode source)
        {
            base.Import(source);
            floats = source.Floats;
            ints = source.Ints;
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rLodSelectorNode)base.Export(modelExporter);
            result.Floats = floats;
            result.Ints = ints;
            return result;
        }
    }
}

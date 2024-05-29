// SPDX-License-Identifier: MIT

using Swe1rGroup5066 = SWE1R.Assets.Blocks.ModelBlock.Nodes.Group5066;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class Group5066Component : FlaggedNodeComponent<Swe1rGroup5066>
    {
        public float[] floats;
        public int[] ints;

        public override void Import(Swe1rGroup5066 source)
        {
            base.Import(source);
            floats = source.Floats;
            ints = source.Ints;
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rGroup5066)base.Export(modelExporter);
            result.Floats = floats;
            result.Ints = ints;
            return result;
        }
    }
}

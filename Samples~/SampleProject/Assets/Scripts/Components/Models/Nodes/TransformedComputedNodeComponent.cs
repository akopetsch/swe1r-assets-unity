// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rTransformedComputedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedComputedNode;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class TransformedComputedNodeComponent : FlaggedNodeComponent<Swe1rTransformedComputedNode>
    {
        public short word1;
        public short word2;
        public UnityVector3 vector;

        public override void Import(Swe1rTransformedComputedNode source)
        {
            base.Import(source);
            word1 = source.Word1;
            word2 = source.Word2;
            vector = source.Vector.ToUnityVector3();
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rTransformedComputedNode)base.Export(modelExporter);
            result.Word1 = word1;
            result.Word2 = word2;
            result.Vector = vector.ToSwe1rVector3Single();
            return result;
        }
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rTransformedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedNode;
using UnityMatrix4x4 = UnityEngine.Matrix4x4;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class TransformedNodeComponent : FlaggedNodeComponent<Swe1rTransformedNode>
    {
        public UnityMatrix4x4 swe1rTransform;

        public override void Import(Swe1rTransformedNode source)
        {
            base.Import(source);
            swe1rTransform = source.Transform.ToUnity();
            ApplyMatrix(swe1rTransform);
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rTransformedNode)base.Export(modelExporter);
            result.Transform = swe1rTransform.ToSwe1r();
            return result;
        }
    }
}

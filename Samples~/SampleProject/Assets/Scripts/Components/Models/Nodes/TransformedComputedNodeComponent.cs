// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rTransformedComputedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedComputedNode;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class TransformedComputedNodeComponent : FlaggedNodeComponent<Swe1rTransformedComputedNode>
    {
        #region Fields (serialized)

        public short followModelPosition;
        public short orientationOption;
        public UnityVector3 vector;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rTransformedComputedNode source)
        {
            base.Import(source);
            followModelPosition = source.FollowModelPosition;
            orientationOption = source.OrientationOption;
            vector = source.UpVector.ToUnityVector3();
        }

        public override Swe1rFlaggedNode Export(ModelExporter exporter)
        {
            var result = (Swe1rTransformedComputedNode)base.Export(exporter);
            result.FollowModelPosition = followModelPosition;
            result.OrientationOption = orientationOption;
            result.UpVector = vector.ToSwe1rVector3Single();
            return result;
        }

        #endregion
    }
}

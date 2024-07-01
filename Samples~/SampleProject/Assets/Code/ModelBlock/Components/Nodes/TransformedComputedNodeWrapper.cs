// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rTransformedComputedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedComputedNode;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class TransformedComputedNodeWrapper : FlaggedNodeWrapper<Swe1rTransformedComputedNode>
    {
        #region Fields

        public short followModelPosition;
        public short orientationOption;
        public UnityVector3 vector;

        #endregion

        #region Methods

        public override void Import(Swe1rTransformedComputedNode source, ModelBlockItemImporter importer)
        {
            base.Import(source, importer);
            followModelPosition = source.FollowModelPosition;
            orientationOption = source.OrientationOption;
            vector = source.UpVector.ToUnityVector3();
        }

        public override Swe1rTransformedComputedNode Export(ModelBlockItemExporter exporter)
        {
            var result = base.Export(exporter);
            result.FollowModelPosition = followModelPosition;
            result.OrientationOption = orientationOption;
            result.UpVector = vector.ToSwe1rVector3Single();
            return result;
        }

        #endregion
    }
}

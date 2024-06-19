// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rTransformedWithPivotNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedWithPivotNode;
using UnityMatrix4x4 = UnityEngine.Matrix4x4;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class TransformedWithPivotNodeComponent : FlaggedNodeComponent<Swe1rTransformedWithPivotNode>
    {
        #region Fields (serialized)

        public UnityMatrix4x4 swe1rTransform;
        public UnityVector3 pivot;

        #endregion

        #region Methods (import/export)

        public override void Import(Swe1rTransformedWithPivotNode source)
        {
            base.Import(source);
            swe1rTransform = source.Transform.ToUnity();
            pivot = source.Pivot.ToUnityVector3();
            ApplyMatrix(swe1rTransform);
        }

        public override Swe1rFlaggedNode Export(ModelExporter exporter)
        {
            var result = (Swe1rTransformedWithPivotNode)base.Export(exporter);
            result.Transform = swe1rTransform.ToSwe1r();
            result.Pivot = pivot.ToSwe1rVector3Single();
            return result;
        }

        #endregion
    }
}

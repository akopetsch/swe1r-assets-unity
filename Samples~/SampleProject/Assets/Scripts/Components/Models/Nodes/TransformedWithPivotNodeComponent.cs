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
        public UnityMatrix4x4 matrix;
        public UnityVector3 vector;

        public override void Import(Swe1rTransformedWithPivotNode source)
        {
            base.Import(source);
            matrix = source.Matrix.ToUnity();
            vector = source.Vector.ToUnityVector3();
            ApplyMatrix(matrix);
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rTransformedWithPivotNode)base.Export(modelExporter);
            result.Matrix = matrix.ToSwe1r();
            result.Vector = vector.ToSwe1rVector3Single();
            return result;
        }
    }
}

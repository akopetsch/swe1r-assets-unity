// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rBounds3Single = SWE1R.Assets.Blocks.Vectors.Bounds3Single;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using Swe1rMeshGroupNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.MeshGroupNode;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Nodes
{
    public class MeshGroupNodeComponent : FlaggedNodeComponent<Swe1rMeshGroupNode>
    {
        public UnityVector3 boundsMin;
        public UnityVector3 boundsMax;

        public override void Import(Swe1rMeshGroupNode source)
        {
            base.Import(source);
            boundsMin = source.Bounds.Min.ToUnityVector3();
            boundsMax = source.Bounds.Max.ToUnityVector3();
        }

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = (Swe1rMeshGroupNode)base.Export(modelExporter);
            result.Bounds = new Swe1rBounds3Single() {
                Min = boundsMin.ToSwe1rVector3Single(),
                Max = boundsMax.ToSwe1rVector3Single(),
            };
            return result;
        }
    }
}
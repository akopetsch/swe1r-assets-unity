// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rBounds3Single = SWE1R.Assets.Blocks.Vectors.Bounds3Single;
using Swe1rMeshGroupNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.MeshGroupNode;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class MeshGroupNodeWrapper : FlaggedNodeWrapper<Swe1rMeshGroupNode>
    {
        #region Fields

        public UnityVector3 aabbMin;
        public UnityVector3 aabbMax;

        #endregion

        #region Methods

        public override void Import(Swe1rMeshGroupNode source, ModelBlockItemImporter importer)
        {
            base.Import(source, importer);
            aabbMin = source.Aabb.Min.ToUnityVector3();
            aabbMax = source.Aabb.Max.ToUnityVector3();
        }

        public override Swe1rMeshGroupNode Export(ModelBlockItemExporter exporter)
        {
            var result = base.Export(exporter);
            result.Aabb = new Swe1rBounds3Single() {
                Min = aabbMin.ToSwe1rVector3Single(),
                Max = aabbMax.ToSwe1rVector3Single(),
            };
            return result;
        }

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Nodes;
using System;
using UnityEngine;
using Swe1rMeshGroupNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.MeshGroupNode;
using Swe1rMeshGroupNodeOrShorts = SWE1R.Assets.Blocks.ModelBlock.Meshes.MeshGroupNodeOrShorts;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Meshes
{
    [Serializable]
    public class MeshGroupNodeOrShortsWrapper : ModelObjectWrapper<Swe1rMeshGroupNodeOrShorts>
    {
        #region Fields

        [SerializeReference] public MeshGroupNodeWrapper meshGroupNode;
        [SerializeReference] public short[] shorts;

        #endregion

        #region Methods

        public override void Import(Swe1rMeshGroupNodeOrShorts source, ModelBlockItemImporter importer)
        {
            if (source.MeshGroupNode != null)
                meshGroupNode = importer.GetFlaggedNodeComponent<MeshGroupNodeWrapper>(source.MeshGroupNode);
            else if (source.Shorts != null)
                shorts = source.Shorts;
        }

        public override Swe1rMeshGroupNodeOrShorts Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rMeshGroupNodeOrShorts();
            if (meshGroupNode != null)
                result.MeshGroupNode = (Swe1rMeshGroupNode)exporter.GetFlaggedNode(meshGroupNode.gameObject);
            else if (shorts.Length > 0)
                result.Shorts = shorts;
            return result;
        }

        #endregion
    }
}

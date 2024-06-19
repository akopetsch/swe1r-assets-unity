// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Nodes;
using System;
using UnityEngine;
using Swe1rMeshGroupNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.MeshGroupNode;
using Swe1rMeshGroupNodeOrShorts = SWE1R.Assets.Blocks.ModelBlock.Meshes.MeshGroupNodeOrShorts;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class MeshGroupNodeOrShortsObject
    {
        #region Fields (serialized)

        [SerializeReference] public MeshGroupNodeComponent meshGroupNode;
        [SerializeReference] public short[] shorts;

        #endregion

        #region Constructor

        public MeshGroupNodeOrShortsObject(Swe1rMeshGroupNodeOrShorts source, ModelImporter importer)
        {
            if (source.MeshGroupNode != null)
                meshGroupNode = importer.GetFlaggedNodeComponent<MeshGroupNodeComponent>(source.MeshGroupNode);
            else if (source.Shorts != null)
                shorts = source.Shorts;
        }

        #endregion

        #region Methods (export)

        public Swe1rMeshGroupNodeOrShorts Export(ModelExporter exporter)
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

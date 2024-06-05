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
        [SerializeReference] public MeshGroupNodeComponent meshGroupNode;
        [SerializeReference] public short[] shorts;

        public MeshGroupNodeOrShortsObject(Swe1rMeshGroupNodeOrShorts source, ModelImporter modelImporter)
        {
            if (source.MeshGroupNode != null)
                meshGroupNode = modelImporter.GetFlaggedNodeComponent<MeshGroupNodeComponent>(source.MeshGroupNode);
            else if (source.Shorts != null)
                shorts = source.Shorts;
        }

        public Swe1rMeshGroupNodeOrShorts Export(ModelExporter modelExporter)
        {
            var result = new Swe1rMeshGroupNodeOrShorts();
            if (meshGroupNode != null)
                result.MeshGroupNode = (Swe1rMeshGroupNode)modelExporter.GetFlaggedNode(meshGroupNode.gameObject);
            else if (shorts.Length > 0)
                result.Shorts = shorts;
            return result;
        }
    }
}

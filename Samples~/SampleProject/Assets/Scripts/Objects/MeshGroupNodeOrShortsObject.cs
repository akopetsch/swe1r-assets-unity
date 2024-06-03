// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Nodes;
using System;
using UnityEngine;
using Swe1rMeshGroupNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.MeshGroupNode;
using Swe1rMeshGroupOrShorts = SWE1R.Assets.Blocks.ModelBlock.Meshes.MeshGroupOrShorts;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class MeshGroupNodeOrShortsObject
    {
        [SerializeReference] public MeshGroupNodeComponent meshGroupNode;
        [SerializeReference] public short[] shorts;

        public MeshGroupNodeOrShortsObject(Swe1rMeshGroupOrShorts source, ModelImporter modelImporter)
        {
            if (source.MeshGroup != null)
                meshGroupNode = modelImporter.GetFlaggedNodeComponent<MeshGroupNodeComponent>(source.MeshGroup);
            else if (source.Shorts != null)
                shorts = source.Shorts;
        }

        public Swe1rMeshGroupOrShorts Export(ModelExporter modelExporter)
        {
            var result = new Swe1rMeshGroupOrShorts();
            if (meshGroupNode != null)
                result.MeshGroup = (Swe1rMeshGroupNode)modelExporter.GetFlaggedNode(meshGroupNode.gameObject);
            else if (shorts.Length > 0)
                result.Shorts = shorts;
            return result;
        }
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Nodes;
using UnityEngine;
using Swe1rLodSelectorNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.LodSelectorNode;
using Swe1rLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.LodSelectorNodeChildReference;

namespace SWE1R.Assets.Blocks.Unity.Components.Models
{
    public class LodSelectorNodeChildReferenceComponent : MonoBehaviour
    {
        public LodSelectorNodeComponent lodSelectorNode;
        public int index;

        public void Import(Swe1rLodSelectorNodeChildReference source, ModelImporter importer)
        {
            lodSelectorNode = importer.GetFlaggedNodeComponent<LodSelectorNodeComponent>(source.LodSelectorNode);
            index = source.Index;

            gameObject.name = $"{lodSelectorNode.gameObject.name} [{index}]";
        }

        public Swe1rLodSelectorNodeChildReference Export(ModelExporter exporter)
        {
            var result = new Swe1rLodSelectorNodeChildReference();

            result.LodSelectorNode = (Swe1rLodSelectorNode)exporter.GetFlaggedNode(lodSelectorNode.gameObject);
            result.Index = index;
            
            return result;
        }
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using UnityEngine;
using Swe1rFlaggedNodeOrLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.FlaggedNodeOrLodSelectorNodeChildReference;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swer1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class AltNComponent : MonoBehaviour
    {
        #region Methods (import/export)

        public void Import(List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference> source, ModelImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.AltN);

            foreach (Swe1rFlaggedNodeOrLodSelectorNodeChildReference item in source)
            {
                if (item.FlaggedNode != null)
                    importer.CreateFlaggedNodeGameObject(item.FlaggedNode, gameObject);
                else
                    gameObject.AddChild().AddComponent<LodSelectorNodeChildReferenceComponent>()
                        .Import(item.LodSelectorNodeChildReference, importer);
            }
        }

        public List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference> Export(ModelExporter exporter)
        {
            var result = new List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference>();
            foreach (GameObject go in gameObject.GetChildren())
            {
                var item = new Swe1rFlaggedNodeOrLodSelectorNodeChildReference();

                Swer1rFlaggedNode flaggedNode = exporter.GetFlaggedNode(go);
                if (flaggedNode != null)
                    item.FlaggedNode = flaggedNode;
                else
                    item.LodSelectorNodeChildReference =
                            go.GetComponent<LodSelectorNodeChildReferenceComponent>()
                            .Export(exporter);

                result.Add(item);
            }
            return result;
        }

        #endregion
    }
}

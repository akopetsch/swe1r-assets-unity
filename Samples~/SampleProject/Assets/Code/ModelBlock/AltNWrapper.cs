﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using UnityEngine;
using Swe1rFlaggedNodeOrLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.FlaggedNodeOrLodSelectorNodeChildReference;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swer1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class AltNWrapper : ModelMonoBehaviourWrapper<List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference>>
    {
        #region Methods

        public override void Import(List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference> source, ModelBlockItemImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.AltN);

            foreach (Swe1rFlaggedNodeOrLodSelectorNodeChildReference item in source)
            {
                if (item.FlaggedNode != null)
                    importer.CreateFlaggedNodeGameObject(item.FlaggedNode, gameObject);
                else
                    gameObject.AddChild().AddComponent<LodSelectorNodeChildReferenceWrapper>()
                        .Import(item.LodSelectorNodeChildReference, importer);
            }
        }

        public override List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference> Export(ModelBlockItemExporter exporter)
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
                            go.GetComponent<LodSelectorNodeChildReferenceWrapper>()
                            .Export(exporter);

                result.Add(item);
            }
            return result;
        }

        #endregion
    }
}

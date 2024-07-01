// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using UnityEngine;
using Swe1rFlaggedNodeOrInteger = SWE1R.Assets.Blocks.ModelBlock.FlaggedNodeOrInteger;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swer1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class NodesWrapper : AbstractModelComponent<List<Swe1rFlaggedNodeOrInteger>>
    {
        #region Methods

        public override void Import(List<Swe1rFlaggedNodeOrInteger> source, ModelBlockItemImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.Nodes);

            for (int i = 0; i < source.Count; i++)
            {
                Swe1rFlaggedNodeOrInteger flaggedNodeOrInteger = source[i];
                Swer1rFlaggedNode flaggedNode = flaggedNodeOrInteger.FlaggedNode;
                int? integer = flaggedNodeOrInteger.Integer;

                if (flaggedNodeOrInteger.Value == null)
                    gameObject.AddChild().AddComponent<NullWrapper>().Import();
                else if (flaggedNode != null)
                    importer.CreateFlaggedNodeGameObject(flaggedNode, gameObject);
                else if (integer.HasValue)
                    gameObject.AddChild().AddComponent<IntegerWrapper>().Import(integer.Value, importer);
            }
        }

        public override List<Swe1rFlaggedNodeOrInteger> Export(ModelBlockItemExporter exporter)
        {
            var result = new List<Swe1rFlaggedNodeOrInteger>();
            foreach (GameObject go in gameObject.GetChildren())
            {
                Swer1rFlaggedNode flaggedNode = exporter.GetFlaggedNode(go);
                int? integer = go.GetComponent<IntegerWrapper>()?.Export(exporter);

                var item = new Swe1rFlaggedNodeOrInteger();
                if (flaggedNode != null)
                    item.FlaggedNode = flaggedNode;
                else if (integer.HasValue)
                    item.Integer = integer.Value;

                result.Add(item);
            }
            return result;
        }

        #endregion
    }
}

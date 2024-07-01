// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using UnityEngine;
using Swe1rHeaderData = SWE1R.Assets.Blocks.ModelBlock.HeaderData;
using Swe1rLightStreakOrInteger = SWE1R.Assets.Blocks.ModelBlock.LightStreakOrInteger;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class DataComponent : AbstractModelComponent<Swe1rHeaderData>
    {
        #region Methods

        public override void Import(Swe1rHeaderData source, ModelImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.Data);

            foreach (Swe1rLightStreakOrInteger lightStreakOrInteger in source.List)
                gameObject.AddChild().AddComponent<LightStreakOrIntegerComponent>().Import(lightStreakOrInteger, importer);
        }

        public override Swe1rHeaderData Export(ModelExporter exporter)
        {
            var headerData = new Swe1rHeaderData();

            headerData.List = new List<Swe1rLightStreakOrInteger>(); // TODO: auto creation
            foreach (GameObject childGameObject in gameObject.GetChildren())
                headerData.List.Add(childGameObject.GetComponent<LightStreakOrIntegerComponent>().Export(exporter));

            headerData.UpdateSize();

            return headerData;
        }

        #endregion
    }
}

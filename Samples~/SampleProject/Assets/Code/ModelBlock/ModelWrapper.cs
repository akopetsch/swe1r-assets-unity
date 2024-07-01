// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Types;
using System;
using UnityEngine;
using Swe1rModelBlockItem = SWE1R.Assets.Blocks.ModelBlock.ModelBlockItem;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class ModelWrapper : AbstractModelComponent<Swe1rModelBlockItem>
    {
        #region Methods

        public override void Import(Swe1rModelBlockItem source, ModelBlockItemImporter importer)
        {
            // modelComponent
            Type modelComponentType = ModelWrapperFactory.Instance.GetComponentType(source.Model);
            ((IModelWrapper)gameObject.AddComponent(modelComponentType)).Import(source.Model, importer);

            FixTransform();
        }

        private void FixTransform()
        {
            float scale = 0.1f;
            gameObject.transform.Rotate(-90, 0, 0);
            gameObject.transform.localScale = new Vector3(-scale, scale, scale);
        }

        public override Swe1rModelBlockItem Export(ModelBlockItemExporter exporter) =>
            new()
            {
                Model = GetComponent<IModelWrapper>().Export(exporter)
            };

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types;
using System;
using UnityEngine;
using Swe1rModelBlockItem = SWE1R.Assets.Blocks.ModelBlock.ModelBlockItem;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class ModelComponent : MonoBehaviour
    {
        #region Methods (import)

        public void Import(Swe1rModelBlockItem sourc, ModelImporter importer)
        {
            // modelComponent
            Type modelComponentType = ModelComponentFactory.Instance.GetComponentType(sourc.Model);
            ((IModelComponent)gameObject.AddComponent(modelComponentType)).Import(sourc.Model, importer);

            FixTransform();
        }

        private void FixTransform()
        {
            float scale = 0.1f;
            gameObject.transform.Rotate(-90, 0, 0);
            gameObject.transform.localScale = new Vector3(-scale, scale, scale);
        }

        #endregion

        #region Methods (export)

        public Swe1rModelBlockItem Export(ModelExporter exporter) =>
            new()
            {
                Model = GetComponent<IModelComponent>().Export(exporter)
            };

        #endregion
    }
}

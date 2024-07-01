// SPDX-License-Identifier: MIT

using UnityEngine;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public interface IModelWrapper
    {
        #region Properties

        GameObject gameObject { get; }

        #endregion

        #region Methods

        void Import(Swe1rModel model, ModelBlockItemImporter importer);
        Swe1rModel Export(ModelBlockItemExporter exporter);

        #endregion
    }
}

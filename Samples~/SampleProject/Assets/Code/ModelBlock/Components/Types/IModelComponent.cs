﻿// SPDX-License-Identifier: MIT

using UnityEngine;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public interface IModelComponent
    {
        #region Properties

        GameObject gameObject { get; }

        #endregion

        #region Methods

        void Import(Swe1rModel model, ModelImporter importer);
        Swe1rModel Export(ModelExporter exporter);

        #endregion
    }
}
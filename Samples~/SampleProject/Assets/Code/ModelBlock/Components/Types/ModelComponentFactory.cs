// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock;
using System;
using System.Collections.Generic;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public class ModelComponentFactory
    {
        #region Fields

        private static readonly Dictionary<ModelType, Type> componentTypeByModelType = new()
        {
            { ModelType.MAlt, typeof(MAltModelComponent) },
            { ModelType.Modl, typeof(ModlModelComponent) },
            { ModelType.Part, typeof(PartModelComponent) },
            { ModelType.Podd, typeof(PoddModelComponent) },
            { ModelType.Pupp, typeof(PuppModelComponent) },
            { ModelType.Scen, typeof(ScenModelComponent) },
            { ModelType.Trak, typeof(TrakModelComponent) },
        };

        #endregion

        #region Members (singleton)

        public static ModelComponentFactory Instance { get; } = new ModelComponentFactory();
        private ModelComponentFactory() { }

        #endregion

        #region Methods

        public Type GetComponentType(Swe1rModel model) =>
            componentTypeByModelType[model.Type];

        #endregion
    }
}

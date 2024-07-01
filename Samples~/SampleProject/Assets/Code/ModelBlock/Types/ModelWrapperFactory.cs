// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock;
using System;
using System.Collections.Generic;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Types
{
    public class ModelWrapperFactory
    {
        #region Fields

        private static readonly Dictionary<ModelType, Type> componentTypeByModelType = new()
        {
            { ModelType.MAlt, typeof(MAltModelWrapper) },
            { ModelType.Modl, typeof(ModlModelWrapper) },
            { ModelType.Part, typeof(PartModelWrapper) },
            { ModelType.Podd, typeof(PoddModelWrapper) },
            { ModelType.Pupp, typeof(PuppModelWrapper) },
            { ModelType.Scen, typeof(ScenModelWrapper) },
            { ModelType.Trak, typeof(TrakModelWrapper) },
        };

        #endregion

        #region Members (singleton)

        public static ModelWrapperFactory Instance { get; } = new ModelWrapperFactory();
        private ModelWrapperFactory() { }

        #endregion

        #region Methods

        public Type GetComponentType(Swe1rModel model) =>
            componentTypeByModelType[model.Type];

        #endregion
    }
}

﻿// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Swe1rKeyframes = SWE1R.Assets.Blocks.ModelBlock.Animations.Keyframes;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Animations
{
    [Serializable]
    public class KeyframesWrapper : ModelObjectWrapper<Swe1rKeyframes>
    {
        #region Fields

        public List<MaterialTextureWrapper> materialTextures;
        public List<float> floats;

        #endregion

        #region Methods

        public override void Import(Swe1rKeyframes source, ModelBlockItemImporter importer)
        {
            materialTextures = source.MaterialTextures?
                .Select(mt => importer.GetMaterialTextureScriptableObject(mt)).ToList();
            floats = source.Floats;
        }

        public override Swe1rKeyframes Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rKeyframes();
            if (materialTextures?.Count > 0)
                result.MaterialTextures = 
                    materialTextures.Select(mt => exporter.GetMaterialTexture(mt)).ToList();
            else
                result.Floats = floats;
            return result;
        }

        #endregion
    }
}

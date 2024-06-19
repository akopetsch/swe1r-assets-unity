// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Components.Models.Animations;
using SWE1R.Assets.Blocks.Unity.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Swe1rAnimation = SWE1R.Assets.Blocks.ModelBlock.Animations.Animation;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.Components.Models
{
    public class AnimationsComponent : MonoBehaviour
    {
        #region Methods (import/export)

        public void Import(List<Swe1rAnimation> source, ModelImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.Animations);

            foreach (Swe1rAnimation animation in source)
                gameObject.AddChild().AddComponent<AnimationComponent>().Import(animation, importer);
        }

        public List<Swe1rAnimation> Export(ModelExporter exporter) =>
            gameObject.GetComponentsInChildren<AnimationComponent>()
                .Select(ac => ac.Export(exporter)).ToList();

        #endregion
    }
}

// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Animations;
using System.Collections.Generic;
using System.Linq;
using Swe1rAnimation = SWE1R.Assets.Blocks.ModelBlock.Animations.Animation;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class AnimationsWrapper : AbstractModelComponent<List<Swe1rAnimation>>
    {
        #region Methods

        public override void Import(List<Swe1rAnimation> source, ModelBlockItemImporter importer)
        {
            gameObject.name = nameof(Swe1rModel.Animations);

            foreach (Swe1rAnimation animation in source)
                gameObject.AddChild().AddComponent<AnimationWrapper>().Import(animation, importer);
        }

        public override List<Swe1rAnimation> Export(ModelBlockItemExporter exporter) =>
            gameObject.GetComponentsInChildren<AnimationWrapper>()
                .Select(ac => ac.Export(exporter)).ToList();

        #endregion
    }
}

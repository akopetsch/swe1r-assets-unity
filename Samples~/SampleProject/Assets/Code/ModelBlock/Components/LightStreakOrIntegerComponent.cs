// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rLightStreak = SWE1R.Assets.Blocks.ModelBlock.LightStreak;
using Swe1rLightStreakOrInteger = SWE1R.Assets.Blocks.ModelBlock.LightStreakOrInteger;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class LightStreakOrIntegerComponent : AbstractModelComponent<Swe1rLightStreakOrInteger>
    {
        #region Fields

        public SerializableNullable<int> integer;

        #endregion

        #region Methods

        public override void Import(Swe1rLightStreakOrInteger source, ModelBlockItemImporter importer)
        {
            gameObject.name = importer.GetName(source);

            if (source.LightStreak != null)
                transform.Translate(source.LightStreak.Vector.ToUnityVector3());
            else
                integer = source.Integer.Value;
        }

        public override Swe1rLightStreakOrInteger Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rLightStreakOrInteger();
            if (integer.HasValue)
                result.Integer = integer.Value;
            else
                result.LightStreak = new Swe1rLightStreak(transform.localPosition.ToSwe1rVector3Single());
            return result;
        }

        #endregion
    }
}

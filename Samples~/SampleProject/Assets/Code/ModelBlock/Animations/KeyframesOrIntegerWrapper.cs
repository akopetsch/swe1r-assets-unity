// SPDX-License-Identifier: MIT

using System;
using Swe1rKeyframesOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.KeyframesOrInteger;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Animations
{
    [Serializable]
    public class KeyframesOrIntegerWrapper : ModelObjectWrapper<Swe1rKeyframesOrInteger>
    {
        #region Fields

        public KeyframesWrapper keyframes;
        public SerializableNullable<int> integer;

        #endregion

        #region Methods

        public override void Import(Swe1rKeyframesOrInteger source, ModelBlockItemImporter importer)
        {
            if (source.Keyframes != null)
            {
                keyframes = new KeyframesWrapper();
                keyframes.Import(source.Keyframes, importer);
            }
            else
                integer = source.Integer.Value;
        }

        public override Swe1rKeyframesOrInteger Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rKeyframesOrInteger();
            if (integer.HasValue)
                result.Integer = integer.Value;
            else
                result.Keyframes = keyframes.Export(exporter);
            return result;
        }

        #endregion
    }
}

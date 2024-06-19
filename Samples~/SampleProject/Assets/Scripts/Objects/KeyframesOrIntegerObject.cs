// SPDX-License-Identifier: MIT

using System;
using Swe1rKeyframesOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.KeyframesOrInteger;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public class KeyframesOrIntegerObject
    {
        #region Fields (serialized)

        public KeyframesObject keyframes;
        public SerializableNullable<int> integer;

        #endregion

        #region Constructor

        public KeyframesOrIntegerObject(Swe1rKeyframesOrInteger source, ModelImporter importer)
        {
            if (source.Keyframes != null)
                keyframes = new KeyframesObject(source.Keyframes, importer);
            else
                integer = source.Integer.Value;
        }

        #endregion

        #region Methods (export)

        public Swe1rKeyframesOrInteger Export(ModelExporter exporter)
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

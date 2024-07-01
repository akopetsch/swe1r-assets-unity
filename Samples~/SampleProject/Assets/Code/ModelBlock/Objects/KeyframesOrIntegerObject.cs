﻿// SPDX-License-Identifier: MIT

using System;
using Swe1rKeyframesOrInteger = SWE1R.Assets.Blocks.ModelBlock.Animations.KeyframesOrInteger;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Objects
{
    [Serializable]
    public class KeyframesOrIntegerObject : AbstractObject<Swe1rKeyframesOrInteger>
    {
        #region Fields (serialized)

        public KeyframesObject keyframes;
        public SerializableNullable<int> integer;

        #endregion

        #region Methods

        public override void Import(Swe1rKeyframesOrInteger source, ModelImporter importer)
        {
            if (source.Keyframes != null)
            {
                keyframes = new KeyframesObject();
                keyframes.Import(source.Keyframes, importer);
            }
            else
                integer = source.Integer.Value;
        }

        public override Swe1rKeyframesOrInteger Export(ModelExporter exporter)
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

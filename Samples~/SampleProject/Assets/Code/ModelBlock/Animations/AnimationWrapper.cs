// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Animations;
using System.Collections.Generic;
using Swe1rAnimation = SWE1R.Assets.Blocks.ModelBlock.Animations.Animation;
using Swe1rModelImporter = SWE1R.Assets.Blocks.Unity.ModelBlock.ModelBlockItemImporter;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Animations
{
    public class AnimationWrapper : ModelMonoBehaviourWrapper<Swe1rAnimation>
    {
        #region Fields

        public float loopTransitionSpeed;
        public float transitionSpeed;
        public float transitionInterpolationFactor;
        public uint transitionFromThisKeyframeIndex;
        public uint transitionFromThisAnimationTime;
        public float animationStartTime;
        public float animationEndTime;
        public float animationDuration;
        public float duration3;
        public AnimationType animationType;
        public AnimationFlags flags1;
        public uint keyframesCount;
        public float duration4;
        public float duration5;
        public float animationSpeed;
        public float animationTime;
        public int keyframeIndex;
        public List<float> keyframeTimes;
        public KeyframesOrIntegerWrapper keyframesOrInteger;
        public TargetOrIntegerWrapper targetOrInteger;
        public uint unk11;

        #endregion

        #region Methods

        public override void Import(Swe1rAnimation source, Swe1rModelImporter importer)
        {
            gameObject.name = importer.GetName(source);

            loopTransitionSpeed = source.LoopTransitionSpeed;
            transitionSpeed = source.TransitionSpeed;
            transitionInterpolationFactor = source.TransitionInterpolationFactor;
            transitionFromThisKeyframeIndex = source.TransitionFromThisKeyframeIndex;
            transitionFromThisAnimationTime = source.TransitionFromThisAnimationTime;
            animationStartTime = source.AnimationStartTime;
            animationEndTime = source.AnimationEndTime;
            animationDuration = source.AnimationDuration;
            duration3 = source.Duration3;
            animationType = source.AnimationType;
            flags1 = source.Flags1;
            keyframesCount = source.KeyframesCount;
            duration4 = source.Duration4;
            duration5 = source.Duration5;
            animationSpeed = source.AnimationSpeed;
            animationTime = source.AnimationTime;
            keyframeIndex = source.KeyframeIndex;
            keyframeTimes = source.KeyframeTimes;
            keyframesOrInteger = new KeyframesOrIntegerWrapper();
            keyframesOrInteger.Import(source.KeyframesOrInteger, importer);
            targetOrInteger = new TargetOrIntegerWrapper();
            targetOrInteger.Import(source.TargetOrInteger, importer);
            unk11 = source.Unk11;
        }

        public override Swe1rAnimation Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rAnimation();
            
            result.LoopTransitionSpeed = loopTransitionSpeed;
            result.TransitionSpeed = transitionSpeed;
            result.TransitionInterpolationFactor = transitionInterpolationFactor;
            result.TransitionFromThisKeyframeIndex = transitionFromThisKeyframeIndex;
            result.TransitionFromThisAnimationTime = transitionFromThisAnimationTime;
            result.AnimationStartTime = animationStartTime;
            result.AnimationEndTime = animationEndTime;
            result.AnimationDuration = animationDuration;
            result.Duration3 = duration3;
            result.AnimationType = animationType;
            result.Flags1 = flags1;
            result.KeyframesCount = keyframesCount;
            result.Duration4 = duration4;
            result.Duration5 = duration5;
            result.AnimationSpeed = animationSpeed;
            result.AnimationTime = animationTime;
            result.KeyframeIndex = keyframeIndex;
            result.KeyframeTimes = keyframeTimes;
            result.KeyframesOrInteger = keyframesOrInteger.Export(exporter);
            result.TargetOrInteger = targetOrInteger.Export(exporter);
            result.Unk11 = unk11;

            result.UpdateFramesCount();

            return result;
        }

        #endregion
    }
}

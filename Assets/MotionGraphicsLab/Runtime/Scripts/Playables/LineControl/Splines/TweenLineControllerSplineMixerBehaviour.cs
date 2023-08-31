using AnnulusGames.TweenPlayables;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    public class TweenLineControllerSplineMixerBehaviour : TweenAnimationMixerBehaviour<LineControllerSpline, TweenLineControllerSplineBehaviour>
    {
        private FloatValueMixer endAMixer = new FloatValueMixer();
        private FloatValueMixer endBMixer = new FloatValueMixer();

        public override void Blend(LineControllerSpline binding, TweenLineControllerSplineBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.endA.active)
            {
                endAMixer.Blend(behaviour.endA.Evaluate(binding, progress), weight);
            }

            if (behaviour.endB.active)
            {
                endBMixer.Blend(behaviour.endB.Evaluate(binding, progress), weight);
            }
        }

        public override void Apply(LineControllerSpline binding)
        {
            if (endAMixer.ValueCount > 0)
            {
                binding.EndA = endAMixer.Value;
            }
            if (endBMixer.ValueCount > 0)
            {
                binding.EndB = endBMixer.Value;
            }

            endAMixer.Clear();
            endBMixer.Clear();
        }
    }
}
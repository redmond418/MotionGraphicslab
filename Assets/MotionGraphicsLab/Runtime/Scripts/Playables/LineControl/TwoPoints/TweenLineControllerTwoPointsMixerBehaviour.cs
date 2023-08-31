using AnnulusGames.TweenPlayables;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    public class TweenLineControllerTwoPointsMixerBehaviour : TweenAnimationMixerBehaviour<LineControllerTwoPoints, TweenLineControllerTwoPointsBehaviour>
    {
        private Vector2ValueMixer endAMixer = new Vector2ValueMixer();
        private Vector2ValueMixer endBMixer = new Vector2ValueMixer();

        public override void Blend(LineControllerTwoPoints binding, TweenLineControllerTwoPointsBehaviour behaviour, float weight, float progress)
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

        public override void Apply(LineControllerTwoPoints binding)
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
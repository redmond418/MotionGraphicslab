using AnnulusGames.TweenPlayables;
using UnityEngine;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    public class TweenSpriteRendererSizeMixerBehaviour : TweenAnimationMixerBehaviour<SpriteRenderer, TweenSpriteRendererSizeBehaviour>
    {
        private Vector2ValueMixer sizeMixer = new Vector2ValueMixer();

        public override void Blend(SpriteRenderer binding, TweenSpriteRendererSizeBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.size.active)
            {
                sizeMixer.Blend(behaviour.size.Evaluate(binding, progress), weight);
            }
        }

        public override void Apply(SpriteRenderer binding)
        {
            if (sizeMixer.ValueCount > 0)
            {
                binding.size = sizeMixer.Value;
            }

            sizeMixer.Clear();
        }
    }
}
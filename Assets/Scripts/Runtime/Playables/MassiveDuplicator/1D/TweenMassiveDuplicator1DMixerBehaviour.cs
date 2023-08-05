using AnnulusGames.TweenPlayables;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    public class TweenMassiveDuplicator1DMixerBehaviour : TweenAnimationMixerBehaviour<MassiveDuplicator1D, TweenMassiveDuplicator1DBehaviour>
    {
        private IntValueMixer loopCountMixer = new IntValueMixer();
        private Vector3ValueMixer positionMultiplierMixer = new Vector3ValueMixer();
        private Vector3ValueMixer positionOffsetMixer = new Vector3ValueMixer();
        private Vector3ValueMixer eulerMultiplierMixer = new Vector3ValueMixer();
        private Vector3ValueMixer eulerOffsetMixer = new Vector3ValueMixer();
        private Vector3ValueMixer scaleMultiplierMixer = new Vector3ValueMixer();
        private Vector3ValueMixer scaleOffsetMixer = new Vector3ValueMixer();

        public override void Blend(MassiveDuplicator1D binding, TweenMassiveDuplicator1DBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.loopCount.active)
            {
                loopCountMixer.Blend(behaviour.loopCount.Evaluate(binding, progress), weight);
            }

            if (behaviour.positionMultiplier.active)
            {
                positionMultiplierMixer.Blend(behaviour.positionMultiplier.Evaluate(binding, progress), weight);
            }

            if (behaviour.positionOffset.active)
            {
                positionOffsetMixer.Blend(behaviour.positionOffset.Evaluate(binding, progress), weight);
            }

            if (behaviour.eulerMultiplier.active)
            {
                eulerMultiplierMixer.Blend(behaviour.eulerMultiplier.Evaluate(binding, progress), weight);
            }

            if (behaviour.eulerOffset.active)
            {
                eulerOffsetMixer.Blend(behaviour.eulerOffset.Evaluate(binding, progress), weight);
            }

            if (behaviour.scaleMultiplier.active)
            {
                scaleMultiplierMixer.Blend(behaviour.scaleMultiplier.Evaluate(binding, progress), weight);
            }

            if (behaviour.scaleOffset.active)
            {
                scaleOffsetMixer.Blend(behaviour.scaleOffset.Evaluate(binding, progress), weight);
            }
        }

        public override void Apply(MassiveDuplicator1D binding)
        {
            if (loopCountMixer.ValueCount > 0)
            {
                binding.LoopCount = loopCountMixer.Value;
            }
            if (positionMultiplierMixer.ValueCount > 0)
            {
                binding.TransformInfo.positionMultiplier = positionMultiplierMixer.Value;
            }
            if (positionOffsetMixer.ValueCount > 0)
            {
                binding.TransformInfo.positionOffset = positionOffsetMixer.Value;
            }
            if (eulerMultiplierMixer.ValueCount > 0)
            {
                binding.TransformInfo.eulerMultiplier = eulerMultiplierMixer.Value;
            }
            if (eulerOffsetMixer.ValueCount > 0)
            {
                binding.TransformInfo.eulerOffset = eulerOffsetMixer.Value;
            }
            if (scaleMultiplierMixer.ValueCount > 0)
            {
                binding.TransformInfo.scaleMultiplier = scaleMultiplierMixer.Value;
            }
            if (scaleOffsetMixer.ValueCount > 0)
            {
                binding.TransformInfo.scaleOffset = scaleOffsetMixer.Value;
            }

            loopCountMixer.Clear();
            positionMultiplierMixer.Clear();
            positionOffsetMixer.Clear();
            eulerMultiplierMixer.Clear();
            eulerOffsetMixer.Clear();
            scaleMultiplierMixer.Clear();
            scaleOffsetMixer.Clear();
        }
    }
}
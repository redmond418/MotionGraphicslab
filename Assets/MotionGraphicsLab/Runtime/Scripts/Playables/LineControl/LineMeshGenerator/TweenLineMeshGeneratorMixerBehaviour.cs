using AnnulusGames.TweenPlayables;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    public class TweenLineMeshGeneratorMixerBehaviour : TweenAnimationMixerBehaviour<LineMeshGenerator, TweenLineMeshGeneratorBehaviour>
    {
        private ColorValueMixer colorMixer = new ColorValueMixer();
        private FloatValueMixer thicknessMixer = new FloatValueMixer();
        private IntValueMixer endCapDivisionCountMixer = new IntValueMixer();
        private FloatValueMixer endCapStretchMixer = new FloatValueMixer();
        private IntValueMixer cornerDivisionCountMixer = new IntValueMixer();

        public override void Blend(LineMeshGenerator binding, TweenLineMeshGeneratorBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.color.active)
            {
                colorMixer.Blend(behaviour.color.Evaluate(binding, progress), weight);
            }
            if (behaviour.thickness.active)
            {
                thicknessMixer.Blend(behaviour.thickness.Evaluate(binding, progress), weight);
            }
            if (behaviour.endCapDivisionCount.active)
            {
                endCapDivisionCountMixer.Blend(behaviour.endCapDivisionCount.Evaluate(binding, progress), weight);
            }
            if (behaviour.endCapStretch.active)
            {
                endCapStretchMixer.Blend(behaviour.endCapStretch.Evaluate(binding, progress), weight);
            }
            if (behaviour.cornerDivisionCount.active)
            {
                cornerDivisionCountMixer.Blend(behaviour.cornerDivisionCount.Evaluate(binding, progress), weight);
            }
        }

        public override void Apply(LineMeshGenerator binding)
        {
            if (colorMixer.ValueCount > 0)
            {
                binding.Color = colorMixer.Value;
            }
            if (thicknessMixer.ValueCount > 0)
            {
                binding.Thickness = thicknessMixer.Value;
            }
            if (endCapDivisionCountMixer.ValueCount > 0)
            {
                binding.EndCapDivisionCount = endCapDivisionCountMixer.Value;
            }
            if (endCapStretchMixer.ValueCount > 0)
            {
                binding.EndCapStretch = endCapStretchMixer.Value;
            }
            if (cornerDivisionCountMixer.ValueCount > 0)
            {
                binding.CornerDivisionCount = cornerDivisionCountMixer.Value;
            }

            colorMixer.Clear();
            thicknessMixer.Clear();
            endCapDivisionCountMixer.Clear();
            endCapStretchMixer.Clear();
            cornerDivisionCountMixer.Clear();
        }
    }
}
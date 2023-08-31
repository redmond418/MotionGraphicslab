using AnnulusGames.TweenPlayables;
using System;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [Serializable]
    public class TweenLineMeshGeneratorBehaviour : TweenAnimationBehaviour<LineMeshGenerator>
    {
        public ColorTweenParameter color;
        public FloatTweenParameter thickness;
        public IntTweenParameter endCapDivisionCount;
        public FloatTweenParameter endCapStretch;
        public IntTweenParameter cornerDivisionCount;

        public override void OnTweenInitialize(LineMeshGenerator playerData)
        {
            color.SetInitialValue(playerData, playerData.Color);
            thickness.SetInitialValue(playerData, playerData.Thickness);
            endCapDivisionCount.SetInitialValue(playerData, playerData.EndCapDivisionCount);
            endCapStretch.SetInitialValue(playerData, playerData.EndCapStretch);
            cornerDivisionCount.SetInitialValue(playerData, playerData.CornerDivisionCount);
        }
    }

}
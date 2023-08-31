using AnnulusGames.TweenPlayables;
using System;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [Serializable]
    public class TweenLineControllerTwoPointsBehaviour : TweenAnimationBehaviour<LineControllerTwoPoints>
    {
        public Vector2TweenParameter endA;
        public Vector2TweenParameter endB;

        public override void OnTweenInitialize(LineControllerTwoPoints playerData)
        {
            endA.SetInitialValue(playerData, playerData.EndA);
            endB.SetInitialValue(playerData, playerData.EndB);
        }
    }

}
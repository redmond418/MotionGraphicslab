using AnnulusGames.TweenPlayables;
using System;
using UnityEngine;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [Serializable]
    public class TweenSpriteRendererSizeBehaviour : TweenAnimationBehaviour<SpriteRenderer>
    {
        public Vector2TweenParameter size;

        public override void OnTweenInitialize(SpriteRenderer playerData)
        {
            size.SetInitialValue(playerData, playerData.size);
        }
    }

}
using AnnulusGames.TweenPlayables;
using System;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [Serializable]
    public class TweenMassiveDuplicator1DBehaviour : TweenAnimationBehaviour<MassiveDuplicator1D>
    {
        public IntTweenParameter loopCount;
        public Vector3TweenParameter positionMultiplier;
        public Vector3TweenParameter positionOffset;
        public Vector3TweenParameter eulerMultiplier;
        public Vector3TweenParameter eulerOffset;
        public Vector3TweenParameter scaleMultiplier;
        public Vector3TweenParameter scaleOffset;

        public override void OnTweenInitialize(MassiveDuplicator1D playerData)
        {
            loopCount.SetInitialValue(playerData, playerData.LoopCount);
            positionMultiplier.SetInitialValue(playerData, playerData.TransformInfo.positionMultiplier);
            positionOffset.SetInitialValue(playerData, playerData.TransformInfo.positionOffset);
            eulerMultiplier.SetInitialValue(playerData, playerData.TransformInfo.eulerMultiplier);
            eulerOffset.SetInitialValue(playerData, playerData.TransformInfo.eulerOffset);
            scaleMultiplier.SetInitialValue(playerData, playerData.TransformInfo.scaleMultiplier);
            eulerOffset.SetInitialValue(playerData, playerData.TransformInfo.scaleOffset);
        }
    }

}
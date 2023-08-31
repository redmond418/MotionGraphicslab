#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(LineControllerTwoPoints))]
    [TrackClipType(typeof(TweenLineControllerTwoPointsClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween Line Controller Two Points Track")]
#endif
    public class TweenLineControllerTwoPointsTrack : TweenAnimationTrack<LineControllerTwoPoints, TweenLineControllerTwoPointsMixerBehaviour, TweenLineControllerTwoPointsBehaviour> { }
}
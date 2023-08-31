#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(LineControllerSpline))]
    [TrackClipType(typeof(TweenLineControllerSplineClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween Line Controller Splines Track")]
#endif
    public class TweenLineControllerSplineTrack : TweenAnimationTrack<LineControllerSpline, TweenLineControllerSplineMixerBehaviour, TweenLineControllerSplineBehaviour> { }
}
#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(MassiveDuplicator))]
    [TrackClipType(typeof(TweenMassiveDuplicatorClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween Massive Duplicator Track")]
#endif
    public class TweenMassiveDuplicatorTrack : TweenAnimationTrack<MassiveDuplicator, TweenMassiveDuplicatorMixerBehaviour, TweenMassiveDuplicatorBehaviour> { }
}
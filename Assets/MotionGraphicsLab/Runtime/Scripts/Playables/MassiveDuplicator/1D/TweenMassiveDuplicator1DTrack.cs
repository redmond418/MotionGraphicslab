#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(MassiveDuplicator1D))]
    [TrackClipType(typeof(TweenMassiveDuplicator1DClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween Massive Duplicator 1D Track")]
#endif
    public class TweenMassiveDuplicator1DTrack : TweenAnimationTrack<MassiveDuplicator1D, TweenMassiveDuplicator1DMixerBehaviour, TweenMassiveDuplicator1DBehaviour> { }
}
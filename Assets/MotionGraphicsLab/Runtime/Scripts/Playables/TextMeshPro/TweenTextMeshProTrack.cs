#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;
using TMPro;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(TextMeshPro))]
    [TrackClipType(typeof(TweenTextMeshProClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween TextMeshPro Track")]
#endif
    public class TweenTextMeshProTrack : TweenAnimationTrack<TextMeshPro, TweenTextMeshProMixerBehaviour, TweenTextMeshProBehaviour> { }
}
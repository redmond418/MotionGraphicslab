#if UNITY_EDITOR
using System.ComponentModel;
#endif
using AnnulusGames.TweenPlayables;
using UnityEngine.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [TrackBindingType(typeof(LineMeshGenerator))]
    [TrackClipType(typeof(TweenLineMeshGeneratorClip))]
#if UNITY_EDITOR
    [DisplayName("Tween Playables/Motion Graphics/Tween Line Mesh Generator Track")]
#endif
    public class TweenLineMeshGeneratorTrack : TweenAnimationTrack<LineMeshGenerator, TweenLineMeshGeneratorMixerBehaviour, TweenLineMeshGeneratorBehaviour> { }
}
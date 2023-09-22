using UnityEngine;
using UnityEngine.Playables;

namespace Redmond.MotionGraphicsLab
{
    public class RendererEnableClip : PlayableAsset
    {
        [SerializeField] private bool reset = true;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<RendererEnableBehaviour>.Create(graph);
            playable.GetBehaviour().reset = reset;
            return playable;
        }
    }
}

using UnityEngine;
using UnityEngine.Playables;

namespace Redmond.MotionGraphicsLab
{
    public class RendererEnableBehaviour : PlayableBehaviour
    {
        public bool reset = true;
        Renderer component;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            component = playerData as Renderer;
            if (component is null) return;
            if (!component.enabled) component.enabled = true;
            Debug.Log(component.enabled);
        }

        public override void OnGraphStop(Playable playable)
        {
            if (component is null || !reset) return;
            component.enabled = false;
        }/*

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (component is null) return;
            component.enabled = false;
        }*/
    }
}

using UnityEngine;

namespace Redmond.MotionGraphicsLab
{
    public class BoundsDrawer : MonoBehaviour
    {
        [SerializeField] new private Renderer renderer;
        [SerializeField] private Color color = Color.red;

        private void Reset()
        {
            renderer = GetComponent<Renderer>();
        }

        private void OnDrawGizmos()
        {
            if (renderer is null) return;
            Gizmos.color = color;
            Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
        }
    }
}
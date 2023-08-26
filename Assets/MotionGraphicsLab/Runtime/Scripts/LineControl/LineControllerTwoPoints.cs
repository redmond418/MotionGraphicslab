using UnityEngine;

namespace Redmond.MotionGraphicsLab
{
    [ExecuteInEditMode]
    public class LineControllerTwoPoints : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Vector3 endA = Vector3.zero;
        [SerializeField] private Vector3 endB = Vector3.right;
        private readonly Vector3[] ends = new Vector3[2];

        public Vector3 EndA
        {
            get => endA; 
            set => endA = value;
        }
        public Vector3 EndB
        {
            get => EndB;
            set => EndB = value;
        }

        private void Update()
        {
            if (lineRenderer == null) return;
            ends[0] = endA;
            ends[1] = endB;
            lineRenderer.SetPositions(ends);
        }
    }
}

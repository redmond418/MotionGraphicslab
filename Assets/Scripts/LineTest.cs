using DG.Tweening;
using UnityEngine;

namespace Redmond.MotionGraphicsLab
{
    public class LineTest : MonoBehaviour
    {
        [SerializeField] private LineControllerSpline line;
        [SerializeField] private float relativeValue;
        [SerializeField] private float duration;
        [SerializeField] private float delay;
        [SerializeField] private Ease easeA;
        [SerializeField] private Ease easeB;

        void Start ()
        {
            DOTween.To(() => line.EndA, value => line.EndA = value, line.EndA + relativeValue, duration).SetTarget(line).SetDelay(delay).SetEase(easeA).SetLink(gameObject);
            DOTween.To(() => line.EndB, value => line.EndB = value, line.EndB + relativeValue, duration).SetTarget(line).SetEase(easeB).SetLink(gameObject);
        }
    }
}
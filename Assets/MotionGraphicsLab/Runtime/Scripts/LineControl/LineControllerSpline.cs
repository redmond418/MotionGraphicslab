using AnnulusGames.LucidTools.Inspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Redmond.MotionGraphicsLab
{
    [ExecuteInEditMode]
    public class LineControllerSpline : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private SplineContainer splineContainer;
        [SerializeField] private bool isLoop;
        [SerializeField/*, HorizontalGroup("ends"), Range(0, 2)*/] private float endA = 0;
        [SerializeField/*, HorizontalGroup("ends"), Range(0, 2)*/] private float endB = 1;
        [SerializeField] private DivideType divideMode;
        [SerializeField, ShowIf("IsEquidistantDivide")] private int divideCount;
        private Vector3[] positions = new Vector3[2];
        private float[] values = new float[2];
        private readonly List<float> mediumPositionsCache = new();

        private bool IsEquidistantDivide() => divideMode == DivideType.Equidistant;

        public float EndA
        {
            get => endA;
            set => endA = value;
        }
        public float EndB
        {
            get => endB;
            set => endB = value;
        }

        private void Update()
        {
            if (lineRenderer is null || splineContainer is null) return;
            switch (divideMode)
            {
                case DivideType.Equidistant:
                    if (divideCount <= 0) divideCount = 1;
                    if (values.Length != divideCount + 1) Array.Resize(ref values, divideCount + 1);
                    values[0] = endA;
                    values[^1] = endB;
                    for (int i = 1; i < values.Length - 1; i++)
                    {
                        values[i] = Mathf.Lerp(endA, endB, (float)i / divideCount);
                    }
                    break;
                case DivideType.Knots:
                    mediumPositionsCache.Clear();
                    float currentT = 0;
                    float length = splineContainer.Spline.GetLength();
                    float endA2 = isLoop ? endA - (int)endA : Mathf.Clamp01(endA);
                    float endB2 = isLoop ? endB - (int)endB : Mathf.Clamp01(endB);
                    bool inRange = endA2 <= endB2;
                    if (!inRange && !isLoop) endB2 = endA2;
                    int startIndex = -1;
                    for (int i = 0; i < splineContainer.Spline.GetCurveCount(); i++)
                    {
                        currentT += splineContainer.Spline.GetCurveLength(i) / length;
                        if (inRange && endA2 < currentT && currentT < endB2)
                        {
                            mediumPositionsCache.Add(currentT);
                        }
                        else if (isLoop && !inRange && (endA2 < currentT || currentT < endB2))
                        {
                            mediumPositionsCache.Add(currentT);
                            if(startIndex < 0 && endA2 < currentT) startIndex = mediumPositionsCache.Count - 1;
                        }
                    }
                    var count = mediumPositionsCache.Count;
                    if (values.Length != count + 2) Array.Resize(ref values, count + 2);
                    values[0] = endA2;
                    values[^1] = endB2;
                    if(startIndex < 0) startIndex = 0;
                    for (int i = 0; i < count; i++)
                    {
                        values[i + 1] = mediumPositionsCache[(i + startIndex) % count];
                    }
                    break;
                default:
                    return;
            }
            if(positions.Length != values.Length) Array.Resize(ref positions, values.Length);
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = splineContainer.EvaluatePosition(isLoop ? values[i] - (int)values[i] : Mathf.Clamp01(values[i]));
            }
            if (lineRenderer.positionCount != positions.Length) lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }
    }

    public enum DivideType
    {
        Equidistant, Knots
    }
}

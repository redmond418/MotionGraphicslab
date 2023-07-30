using AnnulusGames.LucidTools.Inspector;
using DG.Tweening;
using System;
using UnityEngine;

namespace Redmond.MotionGraphicsLab
{
    [Serializable]
    public struct TweenContext<T>
    {
        public T endValue;
        public float duration;
        public Ease ease;
    }

    public class OrbitMotionTest : MonoBehaviour
    {
        [Serializable]
        private struct ChildOrbitInfo
        {
            public SpriteRenderer orbitSpriteRenderer;
            public float pos;
            private Material _material;
            public Material Material
            {
                get
                {
                    if (_material == null) _material = orbitSpriteRenderer.material;
                    return _material;
                }
            }
        }

        [SerializeField] private ParticleSystem beginParticle;
        [SerializeField] private SpriteRenderer originOrbitSpriteRenderer;
        [SerializeField] private TweenContext<float> originOrbitTweenFirst;
        [SerializeField] private TweenContext<float> orbitTweenFirstExtra;
        [SerializeField] private TweenContext<float> originOrbitTweenSecond;
        [SerializeField] private TweenContext<float> orbitTweenSecondExtra;
        [SerializeField] private ParticleSystem orbitCollisionParticle;
        [SerializeField] private float tweenThirdInterval;
        [SerializeField] private float tweenThirdMinDelay;
        [SerializeField] private TweenContext<float> originOrbitTweenThirdMax;
        [SerializeField] private TweenContext<float> originOrbitTweenThirdMin;
        [SerializeField] private float tweenFourthDelay;
        [SerializeField] private TweenContext<float> originOrbitTweenFourth;
        [SerializeField] private TweenContext<float> originOrbitTweenFifth;
        [SerializeField] private ParticleSystem orbitFinishParticle;
        [SerializeField] private SpriteRenderer ringSpriteRenderer;
        [SerializeField] private TweenContext<float> finishRingTweenRadius;
        [SerializeField] private TweenContext<float> finishRingTweenThickness;
        [SerializeField] private TweenContext<float> finishRoundOrbitsTween;
        [SerializeField] private TweenContext<float> finishRoundOrbitsTweenRadius;
        [SerializeField] private TweenContext<float> finishRoundOrbitsTweenRadiusBack;
        private Material _originOrbitMaterial;
        private Material OriginOrbitMaterial
        {
            get
            {
                if (_originOrbitMaterial == null) _originOrbitMaterial = originOrbitSpriteRenderer.material;
                return _originOrbitMaterial;
            }
        }
        private Material _ringMaterial;
        private Material RingMaterial
        {
            get
            {
                if (_ringMaterial== null) _ringMaterial= ringSpriteRenderer.material;
                return _ringMaterial;
            }
        }

        [SerializeField] private ChildOrbitInfo[] childrenOrbit;
        [SerializeField] private ChildOrbitInfo[] roundOrbits;


        private float initialOriginOrbitMin;
        private float initialOriginOrbitMax;
        private float[] initialChildrenOrbitMin;
        private float[] initialChildrenOrbitMax;
        private float[] initialRoundOrbitsMin;
        private float[] initialRoundOrbitsMax;
        private float[] initialRoundOrbitsRadius;
        private float initialRingRadius;
        private float initialRingThickness;


        private void Start()
        {
            initialChildrenOrbitMin = new float[childrenOrbit.Length];
            initialChildrenOrbitMax = new float[childrenOrbit.Length];
            initialRoundOrbitsMin = new float[roundOrbits.Length];
            initialRoundOrbitsMax = new float[roundOrbits.Length];
            initialRoundOrbitsRadius = new float[roundOrbits.Length];
            initialOriginOrbitMin = OriginOrbitMaterial.GetFloat("_Min");
            initialOriginOrbitMax = OriginOrbitMaterial.GetFloat("_Max");
            for (int i = 0; i < childrenOrbit.Length; i++)
            {
                initialChildrenOrbitMin[i] = childrenOrbit[i].Material.GetFloat("_Min");
                initialChildrenOrbitMax[i] = childrenOrbit[i].Material.GetFloat("_Max");
            }
            for (int i = 0; i < roundOrbits.Length; i++)
            {
                initialRoundOrbitsMin[i] = roundOrbits[i].Material.GetFloat("_Min");
                initialRoundOrbitsMax[i] = roundOrbits[i].Material.GetFloat("_Max");
                initialRoundOrbitsRadius[i] = roundOrbits[i].Material.GetFloat("_Radius");
            }
            initialRingRadius = RingMaterial.GetFloat("_Radius");
            initialRingThickness = RingMaterial.GetFloat("_Thickness");
        }

        private void Initialize()
        {
            OriginOrbitMaterial.SetFloat("_Min", initialOriginOrbitMin);
            OriginOrbitMaterial.SetFloat("_Max", initialOriginOrbitMax);
            for (int i = 0; i < childrenOrbit.Length; i++)
            {
                childrenOrbit[i].Material.SetFloat("_Min", initialChildrenOrbitMin[i]);
                childrenOrbit[i].Material.SetFloat("_Max", initialChildrenOrbitMax[i]);
            }
            for (int i = 0; i < roundOrbits.Length; i++)
            {
                roundOrbits[i].Material.SetFloat("_Min", initialRoundOrbitsMin[i]);
                roundOrbits[i].Material.SetFloat("_Max", initialRoundOrbitsMax[i]);
                roundOrbits[i].Material.SetFloat("_Radius", initialRoundOrbitsRadius[i]);
            }
            RingMaterial.SetFloat("_Radius", initialRingRadius);
            RingMaterial.SetFloat("_Thickness", initialRingThickness);
        }

        [Button, DisableInEditMode]
        private void Play()
        {
            Initialize();
            originOrbitSpriteRenderer.enabled = true;
            beginParticle.Play();
            var sequence = DOTween.Sequence().Append(DOVirtual.Float(0, originOrbitTweenFirst.endValue, originOrbitTweenFirst.duration, value =>
            {
                OriginOrbitMaterial.SetFloat("_Distance", value);
                for (int i = 0; i < childrenOrbit.Length; i++)
                {
                    var child = childrenOrbit[i];
                    if (child.pos <= value && !child.orbitSpriteRenderer.enabled)
                    {
                        child.orbitSpriteRenderer.enabled = true;
                        child.Material.DOFloat(child.pos + orbitTweenFirstExtra.endValue * (i + 1), "_Distance", orbitTweenFirstExtra.duration).SetEase(orbitTweenFirstExtra.ease);
                    }
                }
            }).SetEase(originOrbitTweenFirst.ease))
                .SetLink(gameObject);
            sequence.Append(OriginOrbitMaterial.DOFloat(originOrbitTweenSecond.endValue, "_Distance", originOrbitTweenSecond.duration).SetEase(originOrbitTweenSecond.ease));
            for (int i = 0; i < childrenOrbit.Length; i++)
            {
                sequence.Join(childrenOrbit[i].Material.DOFloat(childrenOrbit[i].pos + orbitTweenSecondExtra.endValue * (i + 1), "_Distance", orbitTweenSecondExtra.duration).SetEase(orbitTweenSecondExtra.ease));
            }
            sequence.AppendCallback(() => orbitCollisionParticle.Play());
            sequence.Append(OriginOrbitMaterial.DOFloat(originOrbitTweenThirdMax.endValue, "_Max", originOrbitTweenThirdMax.duration).SetEase(originOrbitTweenThirdMax.ease))
                .Join(OriginOrbitMaterial.DOFloat(originOrbitTweenThirdMin.endValue, "_Min", originOrbitTweenThirdMin.duration).SetEase(originOrbitTweenThirdMin.ease).SetDelay(tweenThirdMinDelay));
            for (int i = childrenOrbit.Length - 1; i >= 0; i--)
            {
                sequence.Join(childrenOrbit[i].Material.DOFloat(originOrbitTweenThirdMax.endValue, "_Max", originOrbitTweenThirdMax.duration).SetEase(originOrbitTweenThirdMax.ease).SetDelay(tweenThirdInterval - tweenThirdMinDelay));
                sequence.Join(childrenOrbit[i].Material.DOFloat(originOrbitTweenThirdMin.endValue, "_Min", originOrbitTweenThirdMin.duration).SetEase(originOrbitTweenThirdMin.ease).SetDelay(tweenThirdMinDelay));
            }
            sequence.Join(OriginOrbitMaterial.DOFloat(originOrbitTweenFourth.endValue, "_Distance", originOrbitTweenFourth.duration).SetEase(originOrbitTweenFourth.ease).SetDelay(tweenFourthDelay - tweenThirdInterval * childrenOrbit.Length - tweenThirdMinDelay))
                .Append(DOVirtual.Float(originOrbitTweenFourth.endValue, originOrbitTweenFifth.endValue, originOrbitTweenFifth.duration, value =>
                {
                    OriginOrbitMaterial.SetFloat("_Distance", value);
                    foreach (var child in childrenOrbit)
                    {
                        if (child.pos >= value && child.orbitSpriteRenderer.enabled) child.orbitSpriteRenderer.enabled = false;
                    }
                }).SetEase(originOrbitTweenFifth.ease))
                .AppendCallback(() =>
                {
                    originOrbitSpriteRenderer.enabled = false;
                    orbitFinishParticle.Play();
                })
                .Append(RingMaterial.DOFloat(finishRingTweenRadius.endValue, "_Radius", finishRingTweenRadius.duration).SetEase(finishRingTweenRadius.ease))
                .Join(RingMaterial.DOFloat(finishRingTweenThickness.endValue, "_Thickness", finishRingTweenThickness.duration).SetEase(finishRingTweenThickness.ease));
            foreach (var orbit in roundOrbits)
            {
                sequence.Join(orbit.Material.DOFloat(finishRoundOrbitsTween.endValue + orbit.pos, "_Max", finishRoundOrbitsTween.duration).SetEase(finishRoundOrbitsTween.ease))
                    .Join(orbit.Material.DOFloat(finishRoundOrbitsTween.endValue + orbit.pos - 0.001f, "_Min", finishRoundOrbitsTween.duration).SetEase(finishRoundOrbitsTween.ease))
                    .Join(orbit.Material.DOFloat(finishRoundOrbitsTweenRadius.endValue, "_Radius", finishRoundOrbitsTweenRadius.duration).SetEase(finishRoundOrbitsTweenRadius.ease))
                    .Join(orbit.Material.DOFloat(finishRoundOrbitsTweenRadiusBack.endValue, "_Radius", finishRoundOrbitsTweenRadiusBack.duration).SetEase(finishRoundOrbitsTweenRadiusBack.ease).SetDelay(finishRoundOrbitsTweenRadius.duration));
            }
        }
    }
}

using AnnulusGames.LucidTools.Inspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Redmond.MotionGraphicsLab
{
    public class MassiveDuplicator : MonoBehaviour
    {
        [SerializeField] private Renderer prefab;
        [SerializeField] private bool createMaterial;
        [SerializeField, ShowIf("createMaterial")] private Material material;
        [SerializeField] private Transform origin;
        [SerializeField] private Transform parent;
        [SerializeField] private int loopCount;
        [SerializeField, Group("transform")] private TransformContext transformInfo;
        private readonly List<Transform> instances = new();
        private ObjectPool<Transform> pool;

        private Vector3 OriginOffset => origin.position - TransformInfo.anchorPos;
        private Vector3 OriginRotate => origin.eulerAngles - TransformInfo.anchorRot;
        private Vector3 OriginScale => 
            new(origin.localScale.x / TransformInfo.anchorScale.x, origin.localScale.y / TransformInfo.anchorScale.y, origin.localScale.z / TransformInfo.anchorScale.z);

        public int LoopCount
        {
            get => loopCount;
            set => loopCount = value;
        }
        public TransformContext TransformInfo => transformInfo;

        private void Start()
        {
            pool = new(CreateInstance, target => target.gameObject.SetActive(true), 
                target => target.gameObject.SetActive(false), target => Destroy(target), true);
            AdjustLength(loopCount);
        }

        private Transform CreateInstance()
        {
            var instance = Instantiate(prefab, parent);
            if (createMaterial) instance.material = new(material);
            return instance.transform;
        }

        private void AdjustLength(int length)
        {
            if (instances.Count == length) return;
            if(instances.Count < length)
            {
                for (int i = instances.Count; i < length; i++)
                {
                    instances.Add(pool.Get());
                    TransformBuffer(i);
                }
                return;
            }
            else
            {
                for (int i = instances.Count - 1; i >= length; i--)
                {
                    pool.Release(instances[i]);
                    instances.RemoveAt(i);
                }
            }
        }

        private void TransformBuffer(int index)
        {
            instances[index].position = GetVector(index, OriginOffset, transformInfo.positionMultiplier, transformInfo.positionOffset) + TransformInfo.anchorPos;
            instances[index].eulerAngles = GetVector(index, OriginRotate, transformInfo.eulerMultiplier, transformInfo.eulerOffset) + TransformInfo.anchorRot;
            instances[index].localScale = GetVector(index, OriginScale, transformInfo.scaleMultiplier, transformInfo.scaleOffset);
        }

        private Vector3 GetVector(int index, Vector3 originOffset, Vector3 multiplier, Vector3 offset)
        {
            var i = index + 1;
            return new(originOffset.x * Mathf.Pow(multiplier.x, i) + (offset.x * i),
                originOffset.y * Mathf.Pow(multiplier.y, i) + (offset.y * i),
                originOffset.z * Mathf.Pow(multiplier.z, i) + (offset.z * i));
        }

        public void SetAnchors()
        {
            TransformInfo.anchorPos = origin.position;
            TransformInfo.anchorRot = origin.eulerAngles;
            TransformInfo.anchorScale = origin.localScale;
        }

        private void Update()
        {
            if (loopCount < 0) loopCount = 0;
            for (int i = 0; i < instances.Count; i++)
            {
                TransformBuffer(i);
            }
            if (instances.Count != loopCount) AdjustLength(loopCount);
        }
    }

    [Serializable]
    public class TransformContext
    {
        public Vector3 positionMultiplier = Vector3.one;
        public Vector3 positionOffset;
        [Space(20)]
        public Vector3 eulerMultiplier = Vector3.one;
        public Vector3 eulerOffset;
        [Space(20)]
        public Vector3 scaleMultiplier = Vector3.one;
        public Vector3 scaleOffset;
        [Space(20)]
        public Vector3 anchorPos = Vector3.zero;
        public Vector3 anchorRot = Vector3.zero;
        public Vector3 anchorScale = Vector3.one;
    }
}

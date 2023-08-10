using UnityEngine;
using UnityEngine.Pool;
using UniRx;

namespace Redmond.MotionGraphicsLab
{
    public class MassiveDuplicator<T> where T : Component
    {
        private ReactiveCollection<T> _instances = new();
        public T prefab;
        public Transform parent;
        private ObjectPool<T> pool;

        public IReadOnlyReactiveCollection<T> Instances => _instances;

        public MassiveDuplicator(T prefab, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
            pool = new(CreateInstance, target => target.gameObject.SetActive(true),
                target => target.gameObject.SetActive(false), target => Object.Destroy(target), true);
        }

        private T CreateInstance()
        {
            return Object.Instantiate(prefab, parent);
        }

        public void ChangeLength(int length)
        {
            if (_instances.Count == length) return;
            if (_instances.Count < length)
            {
                for (int i = _instances.Count; i < length; i++)
                {
                    _instances.Add(pool.Get());
                }
                return;
            }
            else
            {
                for (int i = _instances.Count - 1; i >= length; i--)
                {
                    pool.Release(_instances[i]);
                    _instances.RemoveAt(i);
                }
            }
        }
    }
}
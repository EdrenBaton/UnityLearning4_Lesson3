using System.Collections.Generic;
using System.Linq;
using Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public abstract class PoolFactory
    {
        private readonly Dictionary<string, HashSet<IPoolable>> _pool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        
        protected PoolFactory(int capacityPool)
        {
            _pool = new Dictionary<string, HashSet<IPoolable>>();
            _capacityPool = capacityPool;

            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }

        public abstract MonoBehaviour GetFromPool(string type);

        protected HashSet<IPoolable> GetPoolList(string type)
        {
            return _pool.ContainsKey(type) ? _pool[type] : _pool[type] = new HashSet<IPoolable>();
        }

        protected IPoolable GetFromPoolList(ISet<IPoolable> poolList, string type)
        {
            var enemy = poolList.FirstOrDefault(a => !(a as MonoBehaviour).gameObject.activeSelf);
                
            if (enemy == null)
            {
                var laser = Resources.Load<BasePoolableObject>(type);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    poolList.Add(instantiate);
                }

                GetFromPoolList(poolList, type);
            }

            enemy = poolList.FirstOrDefault(a => !(a as MonoBehaviour).gameObject.activeSelf);

            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
        
        protected void ActivatePoolObject(Transform transform, Vector2 position, Vector2 force, float torque)
        {
            transform.gameObject.SetActive(true);            
            transform.localPosition = position;
            transform.SetParent(null);
            
            var rb = transform.GetComponent<Rigidbody2D>();
            rb.AddForce(force);
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }
}
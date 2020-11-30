using System;
using Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : BasePoolableObject, IDestroyable
    {
        [SerializeField] private float _health;
        
        public string Name { get; set; }
        public event Action<IHitable> OnHit = f => {};
        public event Action<IHitable> OnDestroy = f => {};
        
        private Transform _rootPool;

        public float Health
        {
            get => _health;
            
            set
            {
                _health = value;
                
                if (_health <= 0.0f)
                {
                    ReturnToPool();
                }
            }
        }

        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }
        
        private void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            OnDestroy(this);
            
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
        public void Hit(float damage)
        {
            Health -= damage;
            OnHit(this);
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}

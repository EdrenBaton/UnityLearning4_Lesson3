using Abstrac_Factory;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : BasePoolableObject
    {
        [SerializeField] private float _damage = 0.37f;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent<IHitable>(out var hitable))
            {
                hitable.Hit(_damage);
            }
        }
    }
}
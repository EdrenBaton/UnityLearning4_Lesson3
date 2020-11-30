using System;
using UnityEngine;

namespace Asteroids
{
    public class BulletPool : PoolFactory
    {
        private readonly Transform _barrel;
        private readonly float _force;

        public BulletPool(int capacityPool, Transform barrel, float force) : base(capacityPool)
        {
            _barrel = barrel;
            _force = force;
        }

        public override MonoBehaviour GetFromPool(string type)
        {
            Bullet result;
            switch (type)
            {
                case "Bullet":
                    result = (Bullet) GetFromPoolList(GetPoolList(type), type);
                    ActivatePoolObject(result.transform,
                        _barrel.position,
                        _barrel.up * _force,
                        0.0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            
            return result;
        }
    }
}
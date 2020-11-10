using System;
using UnityEngine;

namespace Asteroids
{
    public class BulletPool : PoolFactory
    {
        private readonly Vector2 _position;
        private readonly Vector2 _force;

        public BulletPool(int capacityPool, Vector2 position, Vector2 force) : base(capacityPool)
        {
            _position = position;
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
                        _position,
                        _force,
                        0.0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            
            return result;
        }
    }
}
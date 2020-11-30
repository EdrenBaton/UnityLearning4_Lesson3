using System;

namespace Asteroids
{
    public interface IHitable
    {
        string Name { get; set; }
        float Health { get; set; }
        event Action<IHitable> OnHit;
        void Hit(float damage);
    }
}
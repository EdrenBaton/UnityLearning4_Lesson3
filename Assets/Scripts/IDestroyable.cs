using System;

namespace Asteroids
{
    public interface IDestroyable : IHitable
    {
        event Action<IHitable> OnDestroy;
        void Destroy();
    }
}
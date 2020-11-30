using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {        
        public void DependencyInjectHealth(float hp)
        {
            Health = hp;
        }
    }
}

using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Object_Pool
{
    public sealed class EnemyPool : PoolFactory
    {
        private float _asteroidForceMin;
        private float _asteroidForceMax;
        private float _asteroidTorqueMin;
        private float _asteroidTorqueMax;
        private float _respawnRadius = 5.0f;
        
        public EnemyPool(int capacityPool, float asteroidForceMin, float asteroidForceMax, float asteroidTorqueMin, float asteroidTorqueMax) : base(capacityPool)
        {
            _asteroidForceMin = asteroidForceMin;
            _asteroidForceMax = asteroidForceMax;
            _asteroidTorqueMin = asteroidTorqueMin;
            _asteroidTorqueMax = asteroidTorqueMax;
        }

        public override MonoBehaviour GetFromPool(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid1":
                case "Asteroid2":
                    result = (Enemy) GetFromPoolList(GetPoolList(type), type);
                    result.Name = type;
                    ActivatePoolObject(result.transform,
                        Random.insideUnitCircle * _respawnRadius,
                        Random.insideUnitCircle * Random.Range(_asteroidForceMin, _asteroidForceMax),
                        Random.Range(_asteroidTorqueMin, _asteroidTorqueMax));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            
            return result;
        }
    }
}
using Asteroids.Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        // Если это всё унести в scriptableObject, будет вообще красиво, но не успель :(
        [SerializeField] private float _asteroidForceMin = 100.0f;
        [SerializeField] private float _asteroidForceMax = 300.0f;
        [SerializeField] private float _asteroidTorqueMin = -200.0f;
        [SerializeField] private float _asteroidTorqueMax = 200.0f;
        
        private void Start()
        {
            var enemyPool = new EnemyPool(5,
                _asteroidForceMin,
                _asteroidForceMax,
                _asteroidTorqueMin,
                _asteroidTorqueMax);
            
            enemyPool.GetFromPool("Asteroid1");            
            enemyPool.GetFromPool("Asteroid2");
            
            // Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            //
            // IEnemyFactory factory = new AsteroidFactory();
            // factory.Create(new Health(100.0f, 100.0f));
            //
            // Enemy.Factory.Create(new Health(100.0f, 100.0f));
            //
            //
            // var platform = new PlatformFactory().Create(Application.platform);
            //
            // System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }
    }
}

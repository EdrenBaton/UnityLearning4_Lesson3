using UnityEngine;

namespace Asteroids
{
    public class ConsoleHpViewer
    {
        public void Add(IHitable hitable)
        {
            hitable.OnHit += Show;
        }

        private void Show(IHitable hitable)
        {
            if(hitable.Health > 0)
            {
                Debug.Log($"{hitable.Name}'s HP is {hitable.Health}");
            }
        }
    }
}
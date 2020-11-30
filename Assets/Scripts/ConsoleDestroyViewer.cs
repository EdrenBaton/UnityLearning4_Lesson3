using UnityEngine;

namespace Asteroids
{
    public class ConsoleDestroyViewer
    {
        public void Add(IDestroyable destroyable)
        {
            destroyable.OnDestroy += Show;
        }

        private void Show(IHitable hitable)
        {
            Debug.Log($"{hitable.Name} is no more");
        }
    }
}
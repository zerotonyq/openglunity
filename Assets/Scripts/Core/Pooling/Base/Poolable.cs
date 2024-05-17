using UnityEngine;

namespace Core.Pooling.Base
{
    public abstract class Poolable : MonoBehaviour
    {
        public void Activate(Vector2 position)
        {
            gameObject.SetActive(true);
            transform.position = position;
        }

        public void Deactivate() => gameObject.SetActive(false);
    }
}
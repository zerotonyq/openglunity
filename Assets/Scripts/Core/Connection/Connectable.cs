using UnityEngine;

namespace Core.Connection
{
    public class Connectable : MonoBehaviour
    {
        public bool Connected { get; private set; }

        public void Connect(Transform parent, Vector2Int position)
        {
            transform.parent = parent;
            transform.localPosition = new Vector3(position.x, position.y, 0);
            Connected = true;
        }
    }
}
using UnityEngine;

namespace Core.Selection.Base
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private bool dragEnabled = true;

        public void SetDragEnabled(bool i) => dragEnabled = i; 
        public void Drag(Vector2 position)
        {
            if (!dragEnabled)
                return; 
            
            transform.position = position;
        }
    }
}
using UnityEngine;

namespace Core.Selection.Base
{
    public interface ISelectable
    {
        Collider2D Collider { get; }    
        void Select();
        void Deselect();
    }
}
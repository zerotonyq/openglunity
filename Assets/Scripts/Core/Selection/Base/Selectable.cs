using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Selection.Base
{
    [RequireComponent(typeof(Collider2D))]
    public class Selectable : MonoBehaviour
    {
        public Action OnDeselected;
        public Action OnSelected;
        public bool IsSelected { get; private set; }

        public void Select()
        {
            Debug.Log(name + " selected");
            OnSelected?.Invoke();
            IsSelected = true;
        }

        public void Deselect()
        {
            Debug.Log(name + " deselected");
            OnDeselected?.Invoke();
            IsSelected = false;
        }
    }
}
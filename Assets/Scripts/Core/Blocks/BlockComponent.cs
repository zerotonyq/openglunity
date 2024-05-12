using System;
using Core.Connection;
using Core.Connection.Enum;
using Core.Selection.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Blocks
{
    [RequireComponent(typeof(Collider2D))]
    public class BlockComponent : MonoBehaviour, IDraggable, ISelectable
    {
        [SerializeField] private BlockType blockType;
        
        public BlockType BlockType => blockType;
        
        public Collider2D Collider { get; private set; }

        public Action OnDragged;
        
        public void Awake() => Collider = GetComponent<Collider2D>();
        
        public void Select() => Debug.Log("selected " + name);

        public void Deselect() => Debug.Log("deselected " + name);

        private bool _isBlockedPositioning;
        public void BlockPositioning()=>_isBlockedPositioning = true;
        public void Drag(Vector2 position)
        {
            if (_isBlockedPositioning)
                return;
            transform.position = position;
            OnDragged?.Invoke();
        }
    }
}
using System;
using UnityEngine;

namespace Core.Movement.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementView : MonoBehaviour
    {
        public static MovementView Contruct(Vector2 position = default) =>
            new GameObject("movementView").AddComponent<MovementView>();

        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody;

        public void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

        public Action OnBlocked;
        public Action OnUnblocked;

        public void Block() => OnBlocked?.Invoke();
        public void Unblock() => OnUnblocked?.Invoke();
    }
}
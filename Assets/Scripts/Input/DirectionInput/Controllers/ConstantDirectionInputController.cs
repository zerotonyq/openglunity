using System;
using Input.DirectionInput.Base;
using UnityEngine;

namespace Input.DirectionInput
{
    public class ConstantDirectionInputController : IDirectionInput
    {
        private Vector2 _constantDirection;

        public ConstantDirectionInputController(Vector2 constantDirection) => _constantDirection = constantDirection;

        public Vector2 ReadDirection() => _constantDirection;
    }
}
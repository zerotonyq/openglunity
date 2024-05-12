using System;
using UnityEngine;

namespace Input.DirectionInput.Base
{
    public interface IDirectionInput
    {
        //Action<Vector2> OnDirectionChanged { get; }
        Vector2 ReadDirection();
    }
}
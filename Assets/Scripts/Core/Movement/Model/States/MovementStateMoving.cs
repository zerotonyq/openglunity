using System;
using Core.Movement.Fsm.States.Base;
using Core.Movement.View;
using Input.DirectionInput.Base;
using UnityEngine;

namespace Core.Movement.Fsm.States
{
    public class MovementStateMoving : MovementState
    {
        
        public MovementStateMoving(Fsm.Base.Fsm fsm, IDirectionInput directionInputController, MovementView movementView) : 
            base(fsm, directionInputController, movementView)
        {
        }

        public override void Update()
        {
            var currentDirection = DirectionInputController.ReadDirection();
            
            if(currentDirection.magnitude <= 0.01f)
                Fsm.SetState<MovementStateIdle>();
            
            Move(currentDirection);
        }
        
        private void Move(Vector2 direction)
        {
            MovementView.Rigidbody.velocity = direction * 10f;
        }
    }
}
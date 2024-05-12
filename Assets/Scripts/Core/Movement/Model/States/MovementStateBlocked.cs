using System;
using Core.Movement.Fsm.States.Base;
using Core.Movement.View;
using Input.DirectionInput.Base;
using UnityEngine;

namespace Core.Movement.Fsm.States
{
    public class MovementStateBlocked : MovementState
    {
        
        public MovementStateBlocked(Fsm.Base.Fsm fsm, IDirectionInput directionInputController, MovementView movementView) : 
            base(fsm, directionInputController, movementView)
        {
        }

        public override void Enter()
        {
            base.Enter();
            MakeKinematic(true);
        }

        public override void Exit()
        {
            base.Exit();
            MakeKinematic(false);
        }
        
        public void MakeKinematic(bool i)
        {
            MovementView.Rigidbody.velocity = Vector3.zero;
            MovementView.Rigidbody.isKinematic = i;
        }

    }
}
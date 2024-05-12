using Core.Movement.Fsm.Base;
using Core.Movement.View;
using Input.DirectionInput.Base;
using UnityEngine;

namespace Core.Movement.Fsm.States.Base
{
    public abstract class MovementState : FsmState
    {
        protected IDirectionInput DirectionInputController;
        
        protected MovementView MovementView;
        
        public MovementState(Fsm.Base.Fsm fsm, IDirectionInput directionInputController, MovementView movementView) : 
            base(fsm)
        {
            DirectionInputController = directionInputController;
            MovementView = movementView;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered " + this.GetType());
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exited " + this.GetType());
        }
    }
}
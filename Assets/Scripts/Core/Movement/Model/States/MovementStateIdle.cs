using Core.Movement.Fsm.States.Base;
using Core.Movement.View;
using Input.DirectionInput.Base;

namespace Core.Movement.Fsm.States
{
    public class MovementStateIdle : MovementState
    {
        public MovementStateIdle(Fsm.Base.Fsm fsm, IDirectionInput directionInputController, MovementView movementView) : 
            base(fsm, directionInputController, movementView)
        {
        }
        
        public override void Update()
        {
            base.Update();
            if(DirectionInputController.ReadDirection().magnitude > 0.01f)
                Fsm.SetState<MovementStateMoving>();
        }

    }
}
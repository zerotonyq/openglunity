using Core.Movement.Fsm.States;
using Core.Movement.View;
using Input.DirectionInput.Base;
using UnityEngine;
using Zenject;

namespace Core.Movement.Model
{
    public class MovementController : ITickable
    {
        private MovementView _movementView;
        private Fsm.Base.Fsm _fsm;

        public void AssignView(MovementView view)
        {
            _movementView = view;
        }
        
        [Inject]
        public void Initialize(IDirectionInput directionInput, MovementView movementView)
        {
            Debug.Log(movementView.name);
            if(!movementView)
                AssignView(MovementView.Contruct());
            
            AssignView(movementView);
            
            _fsm = new Fsm.Base.Fsm();

            _fsm.AddState(new MovementStateBlocked(_fsm, directionInput, _movementView));
            _fsm.AddState(new MovementStateIdle(_fsm, directionInput, _movementView));
            _fsm.AddState(new MovementStateMoving(_fsm, directionInput, _movementView));
            
            _fsm.SetState<MovementStateIdle>();
            
            Subscribe();
        }

        private void Subscribe()
        {
            _movementView.OnBlocked += () => _fsm.SetState<MovementStateBlocked>();
            _movementView.OnUnblocked += () => _fsm.SetState<MovementStateIdle>();
        }


        public void Tick()
        {
            _fsm.Update();
        }
    }
}
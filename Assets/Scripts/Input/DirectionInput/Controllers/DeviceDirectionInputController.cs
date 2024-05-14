using Input.DirectionInput.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.DirectionInput
{
    public class DeviceDirectionInputController : IDirectionInput
    {
        
        private Vector2 _currentDirection;
        private PlayerInputActions _playerInputActions;
        [Inject]
        public DeviceDirectionInputController(InputActionsManager inputActionsManager)
        {
            _playerInputActions = inputActionsManager.PlayerInputActions;
            _playerInputActions.Base.Movement.performed += ModifyDirection;
            _playerInputActions.Base.Movement.canceled += ModifyDirection;
        }

        private void ModifyDirection(InputAction.CallbackContext ctx) => _currentDirection = ctx.ReadValue<Vector2>();
        public Vector2 ReadDirection() => _currentDirection;
    }
}
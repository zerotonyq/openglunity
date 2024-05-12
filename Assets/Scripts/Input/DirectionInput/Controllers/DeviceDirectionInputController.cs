using Input.DirectionInput.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.DirectionInput
{
    public class DeviceDirectionInputController : IDirectionInput
    {
        private readonly PlayerInputActions _playerInputActions;
        private Vector2 _currentDirection;
        
        [Inject]
        public DeviceDirectionInputController(PlayerInputActions playerInputActions)
        {
            _playerInputActions = playerInputActions;
            _playerInputActions.Base.Enable();
            _playerInputActions.Base.Movement.performed += ModifyDirection;
            _playerInputActions.Base.Movement.canceled += ModifyDirection;
        }

        private void ModifyDirection(InputAction.CallbackContext ctx) => _currentDirection = ctx.ReadValue<Vector2>();
        public Vector2 ReadDirection() => _currentDirection;
    }
}
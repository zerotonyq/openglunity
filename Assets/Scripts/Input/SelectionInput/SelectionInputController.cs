using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;


public class SelectionInputController
{
    private PlayerInputActions _playerInputActions;

    private Vector2 _mousePosition;
    public Vector2 MousePosition => _mousePosition;

    public Action<Vector2> OnSelectPositionChanged;
    public Action<Vector2> OnSelected;
    public Action OnDeselected;
    

    [Inject]
    public SelectionInputController(InputActionsManager inputActionsManager)
    {
        _playerInputActions = inputActionsManager.PlayerInputActions;
        _playerInputActions.Base.SelectPosition.performed += ReadSelectPosition;

        _playerInputActions.Base.Select.performed += ReadSelect;
        _playerInputActions.Base.Select.canceled += ReadDeselect;
    }

    private void ReadSelectPosition(InputAction.CallbackContext ctx)
    {
        _mousePosition = ctx.ReadValue<Vector2>();
        OnSelectPositionChanged?.Invoke(_mousePosition);
    }

    private void ReadSelect(InputAction.CallbackContext ctx)
    {
        OnSelected?.Invoke(_mousePosition);
    }

    private void ReadDeselect(InputAction.CallbackContext ctx) => OnDeselected?.Invoke();
}
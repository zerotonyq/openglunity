using System;
using Core.Selection.Base;
using UnityEngine;
using Utils.Camera;
using Zenject;

namespace Core.Selection
{
    public class ObjectSelectionManager
    {
        private readonly SelectionInputController _selectionInputController;

        private ISelectable _currentSelected;

        public Action<GameObject> OnSelected;
        public Action<GameObject> OnDeselected;

        [Inject]
        public ObjectSelectionManager(SelectionInputController selectionInputController)
        {
            _selectionInputController = selectionInputController;
            _selectionInputController.OnSelected += TrySelectObject;
            _selectionInputController.OnDeselected += TryDeselectObject;
        }

        public void TryDeselectObject()
        {
            if (_currentSelected == null)
                return;

            _currentSelected.Deselect();
            OnDeselected?.Invoke(_currentSelected.Collider.gameObject);
        }

        public void TrySelectObject(Vector2 screenPosition)
        {
            var collider = CameraRaycaster.Raycast(screenPosition);

            if (collider == null)
                return;

            if (!collider.gameObject.TryGetComponent(out ISelectable selectable))
                return;

            selectable.Select();
            _currentSelected = selectable;
            OnSelected?.Invoke(collider.gameObject);
        }
    }
}
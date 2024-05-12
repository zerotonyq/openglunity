using Core.Selection.Base;
using UnityEngine;
using Zenject;

namespace Core.Selection.Drag
{
    public class ObjectDraggingManager
    {
        private ObjectSelectionManager _objectSelectionManager;
        private SelectionInputController _selectionInputController;

        private IDraggable _currentDraggable;

        [Inject]
        public ObjectDraggingManager(ObjectSelectionManager objectSelectionManager,
            SelectionInputController selectionInputController)
        {
            _objectSelectionManager = objectSelectionManager;
            _selectionInputController = selectionInputController;

            objectSelectionManager.OnSelected += TryAssignDraggable;
            objectSelectionManager.OnDeselected += TryUnassignDraggable;
            _selectionInputController.OnSelectPositionChanged += DragCurrent;
        }

        private void TryAssignDraggable(GameObject selectedObject)
        {
            if (!selectedObject.TryGetComponent(out IDraggable draggable))
                return;

            _currentDraggable = draggable;
        }

        private void TryUnassignDraggable(GameObject selectedObject)
        {
            _currentDraggable = null;
        }

        public void DragCurrent(Vector2 screenPosition)
        {
            if (_currentDraggable == null)
                return;
            var worldPointPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            
            _currentDraggable.Drag(worldPointPosition);
            
            
        }
    }
}
using Core.Blocks;
using Core.Connection;
using Core.Movement.Model;
using Core.Movement.View;
using Core.Selection;
using Core.Selection.Drag;
using Input;
using Input.DirectionInput;
using Input.DirectionInput.Base;
using Zenject;

namespace DI
{
    public class GameplayInstaller : MonoInstaller
    {
        public MovementView prefab;
        public override void InstallBindings()
        {
            //movement of the player
            Container.Bind<ITickable>().To<MovementController>().AsSingle().NonLazy();
            Container.Bind<IDirectionInput>().To<DeviceDirectionInputController>().AsSingle();

            
            //input selection and dragging
            Container.Bind<InputActionsManager>().AsSingle().NonLazy();
            Container.Bind<SelectionInputController>().AsSingle().NonLazy();
            Container.Bind<ObjectSelectionManager>().AsSingle().NonLazy();
            Container.Bind<ObjectDraggingManager>().AsSingle().NonLazy();
            
            
            var view = Container.InstantiatePrefab(prefab).GetComponent<MovementView>();
            Container.BindInstance(view);
            Container.BindInstance(view.GetComponent<GridConnectionController>()).AsSingle();
            Container.BindInstance(view.GetComponent<BlockMergeController>()).AsSingle();
        }
    }
}
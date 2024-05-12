using Core.Movement.Model;
using Core.Movement.View;
using Core.Selection;
using Core.Selection.Drag;
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
            var view = Container.InstantiatePrefab(prefab).GetComponent<MovementView>();
            Container.BindInstance(view);
            
            Container.Bind<PlayerInputActions>().AsSingle();
            
            Container.Bind<SelectionInputController>().AsSingle().NonLazy();
            Container.Bind<IDirectionInput>().To<DeviceDirectionInputController>().AsSingle();

            Container.Bind<ObjectSelectionManager>().AsSingle().NonLazy();
            Container.Bind<ObjectDraggingManager>().AsSingle().NonLazy();
            
            Container.Bind<ITickable>().To<MovementController>().AsSingle().NonLazy();
        }
    }
}
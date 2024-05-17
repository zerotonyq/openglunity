using Core.Blocks;
using Core.Connection;
using Core.EntryPoint;
using Core.Gears.Weapons;
using Core.Movement.Model;
using Core.Movement.View;
using Core.Pooling;
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
        public Projectile projectilePrefab;
        public Rifle enemyPrefab;
        public override void InstallBindings()
        {
            //movement of the player
            Container.Bind<IDirectionInput>().To<DeviceDirectionInputController>().AsSingle();

            
            //input selection and dragging
            Container.Bind<InputActionsManager>().AsSingle().NonLazy();
            Container.Bind<SelectionInputController>().AsSingle().NonLazy();
            Container.Bind<ObjectSelectionManager>().AsSingle().NonLazy();
            Container.Bind<ObjectDraggingManager>().AsSingle().NonLazy();


            Container.Bind<PoolManager>().AsSingle().NonLazy();
            Container.Bind<GameplayEntryPoint>().AsSingle().WithArguments(projectilePrefab, enemyPrefab).NonLazy();
        }
    }
}
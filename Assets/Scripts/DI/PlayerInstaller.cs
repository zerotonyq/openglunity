using System.Collections;
using System.Collections.Generic;
using Core.Connection;
using Core.Movement.Model;
using Core.Movement.View;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
   public MovementView prefab;
   
   public override void InstallBindings()
   {
      Container.Bind<ITickable>().To<MovementController>().AsSingle().NonLazy();
      
      var view = Container.InstantiatePrefab(prefab).GetComponent<MovementView>();
      Container.BindInstance(view);
      Container.BindInstance(view.GetComponent<GridConnectionController>()).AsSingle();
   }
}

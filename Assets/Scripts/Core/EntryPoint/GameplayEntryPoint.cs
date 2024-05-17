using Core.Gears.Weapons;
using Core.Gears.Weapons.Base;
using Core.Movement.View;
using Core.Pooling;
using UnityEngine;
using Zenject;

namespace Core.EntryPoint
{
    public class GameplayEntryPoint
    {
        private Projectile _projectilePrefab;
        [Inject]
        public void Initialize(MovementView playerMovementView, Projectile projectilePrefab, Rifle enemyPrefab)
        {
            for (int i = 0; i < 5; i++)
            {
                var projectile = GameObject.Instantiate(projectilePrefab);
                projectile.Deactivate();
                PoolManager.Instance.Put(projectile);
            }

            for (int i = 0; i < 5; i++)
            {
                var en = GameObject.Instantiate(enemyPrefab);
                    en.Initialize(2, false);
                    en.transform.position = new Vector3(i+i, i+i);
            }
            playerMovementView.GetComponent<BlockDetector>().Initialize(1, 10, LayerMask.NameToLayer("Enemy"), 5);
            playerMovementView.GetComponent<BlockDetector>().StartDetection();
            playerMovementView.GetComponent<Rifle>().Initialize(2f, true);

        }
    }
}
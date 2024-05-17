using System;
using Core.Blocks;
using Core.Gears.Weapons.Base;
using Core.Pooling;
using UnityEngine;

namespace Core.Gears.Weapons
{
    [RequireComponent(typeof(BlockDetector))]
    public class Rifle : BlockComponent, IShootable
    {
        private Vector2 _currentAimDirection;
        private float _projectileSpeedMultiplier;
        private bool _isPlayer;

        public void Initialize(float projectileSpeedMultiplier, bool isPlayer)
        {
            InitializeHealth(1, 1);
            _isPlayer = isPlayer;
            _projectileSpeedMultiplier = projectileSpeedMultiplier;

            GetComponent<BlockDetector>().OnBlockDetected += Aim;
        }

        public void Shoot()
        {
            if (_currentAimDirection == Vector2.zero)
                return;

            var projectile = PoolManager.Instance.Get<Projectile>();

            if (!projectile)
                return;

            projectile.Initialize(1,
                _isPlayer ? LayerMask.NameToLayer("Player") : LayerMask.NameToLayer("Enemy"));

            projectile.Activate(transform.position);

            projectile.GetComponent<Rigidbody2D>().velocity = _currentAimDirection.normalized * _projectileSpeedMultiplier;
        }


        public void Aim(BlockComponent block)
        {
            _currentAimDirection = block.transform.position - transform.position;
            Shoot();
        }
    }
}
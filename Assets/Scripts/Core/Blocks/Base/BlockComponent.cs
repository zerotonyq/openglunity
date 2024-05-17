using System;
using Core.Selection.Base;
using ModestTree.Util;
using UnityEngine;

namespace Core.Blocks
{
    public abstract class BlockComponent : MonoBehaviour
    {
        public Action OnKilled;

        public bool isConnected;
        
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public void InitializeHealth(int health, int maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
            OnKilled += () => Debug.Log(name + " killed");
        }

        public void AddHealth(int value)
        {
            if (value < 0)
                return;

            if (Health + value > MaxHealth)
                Health = MaxHealth;
            else
                Health += value;
        }

        public void Damage(int value)
        {
            if (value < 0)
                return;

            Health -= value;

            if (Health <= 0)
            {
                Health = 0;
                OnKilled?.Invoke();
            }
        }
    }
}
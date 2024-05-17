using System.Collections.Generic;
using Core.Blocks;
using UnityEngine;

namespace Core.Gears.Weapons
{
    public interface IShootable
    {
        void Shoot();
        void Aim(BlockComponent gear);
    }
}
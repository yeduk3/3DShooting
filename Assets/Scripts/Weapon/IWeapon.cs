using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeapon
    {
        bool IsAttacking();

        float GetDamage();

        void Equiped();

        void Attack();
    }
}

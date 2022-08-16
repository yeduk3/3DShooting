using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeapon
    {
        float GetDamage();

        void Equiped();

        void Attack();

        string GetName();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeapon
    {
        // void SetDamage(float _damage);

        float GetDamage();

        void Equiped();

        void Attack();
    }
}

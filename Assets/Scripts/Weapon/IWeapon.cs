using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeapon
    {
        void Equiped();

        void Attack();

        string GetName();
    }
}

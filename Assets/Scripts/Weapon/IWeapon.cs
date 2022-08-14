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

        void DamagedToID(int enemyID);

        bool AlreadyBeenDamaged(int enemyID);

        void ClearDamagedEnemyIDList();
    }
}

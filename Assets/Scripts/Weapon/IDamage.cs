using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IDamage
    {
        float GetDamage();
        
        void DamagedToID(int enemyID);

        bool AlreadyBeenDamaged(int enemyID);

        void ClearDamagedEnemyIDList();

        bool IsDamaging();

        IWeapon GetAttackWeapon();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IDamage
    {
        void DamagedToID(int enemyID);

        bool AlreadyBeenDamaged(int enemyID);

        void ClearDamagedEnemyIDList();

        IWeapon GetAttackWeapon();
    }
}
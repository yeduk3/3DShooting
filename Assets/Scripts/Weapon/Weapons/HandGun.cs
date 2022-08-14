using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class HandGun : MonoBehaviour, IWeapon
{
    // Default Striking Power
    private const  float DefaultSTR = 3.0f;
    private float damage = 3.0f;
    // Data for damage enemies only once.
    private List<int> damagedEnemyIDList = new List<int>();

    public float GetDamage()
    {
        return damage;
    }

    public void Equiped()
    {
        // SetDamage(damage);
    }

    public void Attack()
    {
        Debug.Log("Attack in damage " + GetDamage());
    }

    // Excuted when this weapon is damaging enemy. Save the enemy's ID.
    public void DamagedToID(int enemyID)
    {
        damagedEnemyIDList.Add(enemyID);
    }

    // Excuted for check whether this weapon damaged an enemy
    public bool AlreadyBeenDamaged(int enemyID)
    {
        return damagedEnemyIDList.Contains(enemyID);
    }

    // Clear the list of damaged enemy's IDs
    public void ClearDamagedEnemyIDList()
    {
        damagedEnemyIDList.Clear();
    }
}

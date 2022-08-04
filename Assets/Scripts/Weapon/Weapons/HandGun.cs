using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class HandGun : MonoBehaviour, IWeapon
{
    private float damage = 3.0f;

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
}

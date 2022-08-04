using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class BasicSword : MonoBehaviour, IWeapon
{
    private float damage = 4.0f;

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

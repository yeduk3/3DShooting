using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : Weapon
{
    private float iniDamage = 4.0f;

    public override void Equiped()
    {
        SetDamage(iniDamage);
    }

    public override void Attack()
    {
        Debug.Log("Attack in damage " + GetDamage());
    }
}

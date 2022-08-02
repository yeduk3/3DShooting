using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private float damage;

    protected void SetDamage(float _damage) { this.damage = _damage; }

    protected float GetDamage() { return damage; }

    public virtual void Equiped() {}

    public virtual void Attack() {}
}

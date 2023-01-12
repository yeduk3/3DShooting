using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

// enum for play animation clearily
enum SwingState
{
    // No Action.
    Idle = 0,
    // Swing Sword. Any Additional Input Ignored.
    Swinging = 1,
    // Get Additional Input.
    AdditionalHit = 2,
    // Do Additional Swing. And Change To State Idle.
    AdditionalSwing = 3,
}

public class BasicSword : MonoBehaviour, IWeapon, IDamage
{
    // Animation Parameter Name
    private const string pSwingState = "SwingState";

    // Default Striking Power
    private const float DefaultSTR = 4.0f;
    // Changeable Striking Power and will be damage enemy
    private float damage = 4.0f;
    // Data for damage enemies only once.
    private List<int> damagedEnemyIDList = new List<int>();

    private Animator animator;

    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        // Left Mouse Click to First Swing
        if(Input.GetMouseButtonDown(0))
        {
            if(animator.GetInteger(pSwingState) == ((int)SwingState.Idle))
            {
                Attack();
            }
        }
        // Right Mouse Click to Additional Swing
        else if(Input.GetMouseButtonDown(1))
        {
            if(animator.GetInteger(pSwingState) == ((int)SwingState.AdditionalHit))
            {
                AdditionalAttack();
            }
        }
    }

    // IDamage
    public float GetDamage()
    {
        return damage;
    }

    // Method to Change Damage in Additional Swing
    private void SetDamage(float _damage)
    {
        this.damage = _damage;
    }

    // IWeapon
    public void Equiped()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
    }

    // IWeapon
    public void Attack()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
    }

    // Additinoal Attack for Basic Sword
    public void AdditionalAttack()
    {
        ClearDamagedEnemyIDList();

        SetDamage(DefaultSTR * 1.2f);

        animator.SetInteger(pSwingState, ((int)SwingState.AdditionalSwing));
    }

    // Animation Events 1
    public void FirstSwingWait()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.AdditionalHit));
    }

    // Animation Events 2
    public void KeepSwing()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
    }

    // Animation Events 3
    public void SwingEnd()
    {
        ClearDamagedEnemyIDList();

        SetDamage(DefaultSTR);

        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
        print("Swing End");
    }

    // IDamage, Excuted when this weapon is damaging enemy. Save the enemy's ID.
    public void DamageToEnemyByID(int enemyID)
    {
        damagedEnemyIDList.Add(enemyID);
    }

    // IDamage, Excuted for check whether this weapon damaged an enemy
    public bool AlreadyBeenDamaged(int enemyID)
    {
        return damagedEnemyIDList.Contains(enemyID);
    }

    // IDamage, Clear the list of damaged enemy's IDs
    public void ClearDamagedEnemyIDList()
    {
        damagedEnemyIDList.Clear();
    }

    // IDamage, Return the IWeapon
    public IWeapon GetAttackWeapon()
    {
        return this;
    }

    // IDamage, Return whether the state is idle
    public bool IsDamaging()
    {
        return animator.GetInteger(pSwingState) == (int)(SwingState.Swinging) || animator.GetInteger(pSwingState) == (int)(SwingState.AdditionalSwing);
    }

    // Return Object's Name
    public string GetName()
    {
        return gameObject.name;
    }
}

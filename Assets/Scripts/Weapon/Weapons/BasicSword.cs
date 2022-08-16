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

        if(Input.GetMouseButtonDown(0))
        {
            if(animator.GetInteger(pSwingState) == ((int)SwingState.Idle))
            {
                Attack();
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if(animator.GetInteger(pSwingState) == ((int)SwingState.AdditionalHit))
            {
                AdditionalAttack();
            }
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    private void SetDamage(float _damage)
    {
        this.damage = _damage;
    }

    public void Equiped()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
    }

    public void Attack()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
    }

    public void AdditionalAttack()
    {
        ClearDamagedEnemyIDList();

        SetDamage(DefaultSTR * 1.2f);

        animator.SetInteger(pSwingState, ((int)SwingState.AdditionalSwing));
    }

    public void FirstSwingWait()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.AdditionalHit));
    }

    public void KeepSwing()
    {
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
    }

    public void SwingEnd()
    {
        ClearDamagedEnemyIDList();

        SetDamage(DefaultSTR);

        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
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

    public IWeapon GetAttackWeapon()
    {
        return this;
    }

    public string GetName()
    {
        return gameObject.name;
    }
}

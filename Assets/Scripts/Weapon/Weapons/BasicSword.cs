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

public class BasicSword : MonoBehaviour, IWeapon
{
    private const string pSwingState = "SwingState";


    private float damage = 4.0f;
    private bool isAttacking = false;

    private Animator animator;

    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        if(Input.GetMouseButtonDown(0))
        {
            if(!IsAttacking() && animator.GetInteger(pSwingState) == ((int)SwingState.Idle))
            {
                Attack();
            }
            else if(IsAttacking() && animator.GetInteger(pSwingState) == ((int)SwingState.AdditionalHit))
            {
                AdditionalAttack();
            }
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Equiped()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
    }

    public void Attack()
    {
        isAttacking = true;
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void AdditionalAttack()
    {
        Debug.Log("Attack in damage " + GetDamage());
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
        isAttacking = false;
        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
    }
}

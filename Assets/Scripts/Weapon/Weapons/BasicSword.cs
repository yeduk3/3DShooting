using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

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
    private float damage = 4.0f;
    private Animator animator;
    private const string pSwingState = "SwingState";

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(animator.GetInteger(pSwingState) == ((int)SwingState.Idle))
            {
                Attack();
            }
            else if(animator.GetInteger(pSwingState) == ((int)SwingState.AdditionalHit))
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
        Debug.Log("Attack in damage " + GetDamage());
        animator.SetInteger(pSwingState, ((int)SwingState.Swinging));
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
        animator.SetInteger(pSwingState, ((int)SwingState.Idle));
    }
}

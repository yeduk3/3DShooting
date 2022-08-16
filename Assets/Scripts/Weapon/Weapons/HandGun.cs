using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

// enum for play animation clearily
enum FireState
{
    // No Action.
    Idle = 0,
    // Fire Bullet. Any Additional Input Ignored.
    Firing = 1,
}

public class HandGun : MonoBehaviour, IWeapon
{
    [Header("Bullet Data")]
    public Transform bulletSpawnPoint;

    private const string pFireState = "FireState";

    // Default Striking Power
    private const float DefaultSTR = 3.0f;
    private float damage = 3.0f;


    private Animator animator;
    
    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        if(Input.GetMouseButtonDown(0))
        {
            // Shot
            if(animator.GetInteger(pFireState) == ((int)FireState.Idle))
            {
                Attack();
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
        animator.SetInteger(pFireState, ((int)FireState.Idle));
    }

    public void Attack()
    {
        SpawnBullet();

        animator.SetInteger(pFireState, ((int)FireState.Firing));
    }

    public void SpawnBullet()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        bullet.GetComponent<Bullet>().BulletSetting(this, bulletSpawnPoint.forward, 2);
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.SetActive(true);
        Debug.Log("Bullet Instantiated from the Pool");
    }

    public void FireEnd()
    {
        animator.SetInteger(pFireState, ((int)FireState.Idle));
    }

    public string GetName()
    {
        return gameObject.name;
    }
}

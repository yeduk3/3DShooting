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


    private Animator animator;
    
    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        bulletSpawnPoint.position = Camera.main.transform.position + Camera.main.transform.forward * 5f;

        if(Input.GetMouseButtonDown(0))
        {
            // Shot
            if(animator.GetInteger(pFireState) == ((int)FireState.Idle))
            {
                Attack();
            }
        }
    }

    public void Equiped()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger(pFireState, ((int)FireState.Idle));
    }

    public void Attack()
    {
        Transform cam = Camera.main.transform;
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        float rayRadius = bullet.GetComponent<SphereCollider>().radius * bullet.transform.localScale.x;
        float distance = Vector3.Distance(bulletSpawnPoint.position, cam.position);
        RaycastHit[] hits = Physics.SphereCastAll(cam.position, rayRadius, cam.forward, distance);
        SpawnBullet(hits.Length == 0);

        animator.SetInteger(pFireState, ((int)FireState.Firing));
    }

    public void SpawnBullet(bool visibility)
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        bullet.GetComponent<Bullet>().BulletSetting(this, Camera.main.transform.forward, 1, visibility);
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.SetActive(true);
        // Debug.Log("Bullet Instantiated from the Pool");
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

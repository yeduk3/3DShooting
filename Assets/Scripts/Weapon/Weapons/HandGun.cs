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
    [SerializeField]
    private int penetrationCount;

    private const string pFireState = "FireState";


    private Animator animator;

    // find direction
    Transform cam;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    
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

    // IWeapon
    public void Equiped()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger(pFireState, ((int)FireState.Idle));
    }

    // IWeapon
    public void Attack()
    {
        // Check the closest point to attack at the point of camera's view
        GameObject bulletPref = ObjectPool.instance.bulletPrefab;

        /*
        float rayRadius = bulletPref.GetComponent<SphereCollider>().radius * bulletPref.transform.localScale.x;
        RaycastHit[] hits = Physics.SphereCastAll(cam.position, rayRadius, cam.forward, Mathf.Infinity);
        
        // Set the bullet's direction
        if(hits.Length == 0) 
        {
            direction = cam.position + cam.forward * 100;
            //print("No Hit");
        }
        else
        {
            direction = hits[0].point - bulletSpawnPoint.position;
            //print("Hit");
        }
*/
        Vector3 direction;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            print("HIt");
            Debug.DrawRay(ray.origin, hit.point, Color.red, 3.0f);
            direction = hit.point - bulletSpawnPoint.position;
        }
        else
        {
            
            direction = cam.position + cam.forward * 100;
        }

        // Spawn the bullet.
        SpawnBullet(direction.normalized);
        animator.SetInteger(pFireState, ((int)FireState.Firing));
    }

    // Spawn the bullet.
    public void SpawnBullet(Vector3 direction)
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        bullet.GetComponent<Bullet>().BulletSetting(this, direction.normalized, penetrationCount);
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.SetActive(true);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class Bullet : MonoBehaviour, IDamage
{
    [Header("Bullet Materials")]
    [SerializeField]
    private Material normalMaterial;
    [SerializeField]
    private Material transparentMaterial;

    [Header("Bullet Data")]
    [SerializeField]
    private int penetrationCount;
    [SerializeField]
    private float bulletSpeed = 5f, lifeTime = 5f;
    private float curLifeTime = 0f;

    // Default Striking Power
    private const float DefaultSTR = 3.0f;
    private float damage = 3.0f;

    // Data for damage enemies only once.
    private List<int> damagedEnemyIDList = new List<int>();

    private HandGun originWeapon;
    private Vector3 direction;

    // Bullet Setting for Spawning
    public void BulletSetting(HandGun originWeapon, Vector3 direction, int penetrationCount, bool visibility = true)
    {
        curLifeTime = 0f;
        ClearDamagedEnemyIDList();

        this.originWeapon = originWeapon;
        this.direction = direction;
        this.penetrationCount = penetrationCount;

        GetComponent<MeshRenderer>().material = visibility ? normalMaterial : transparentMaterial;
    }

    // Bullet Fly & Life Time
    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        if(GetEnemyIDListCount() == penetrationCount) ObjectPool.instance.PoolBullet(gameObject);
        
        curLifeTime += Time.deltaTime;
        if(curLifeTime > lifeTime) ObjectPool.instance.PoolBullet(gameObject);

        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    // IDamage
    public float GetDamage()
    {
        return damage;
    }

    // 
    private void SetDamage(float _damage)
    {
        this.damage = _damage;
    }
    
    // IDamage, Excuted when this weapon is damaging enemy. Save the enemy's ID.
    public void DamagedToID(int enemyID)
    {
        damagedEnemyIDList.Add(enemyID);
        // Debug.Log(GetEnemyIDListCount() + " HIT!!");
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

    // Method to Check Penetration 
    public int GetEnemyIDListCount()
    {
        return damagedEnemyIDList.Count;
    }

    // IDamage, Return the IWeapon
    public IWeapon GetAttackWeapon()
    {
        return originWeapon;
    }

    // IDamage, Return whether the state is idle
    public bool IsDamaging()
    {
        return true;
    }
}

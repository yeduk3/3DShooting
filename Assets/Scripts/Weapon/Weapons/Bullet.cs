using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class Bullet : MonoBehaviour, IDamage
{
    [Header("Bullet Data")]
    [SerializeField]
    private int penetrationCount;
    [SerializeField]
    private float bulletSpeed = 5f, lifeTime = 5f;
    private float curLifeTime = 0f;

    // Data for damage enemies only once.
    private List<int> damagedEnemyIDList = new List<int>();

    private HandGun originWeapon;
    private Vector3 direction;

    public void BulletSetting(HandGun originWeapon, Vector3 direction, int penetrationCount)
    {
        curLifeTime = 0f;
        ClearDamagedEnemyIDList();
        this.originWeapon = originWeapon;
        this.penetrationCount = penetrationCount;
        this.direction = direction;
    }

    void Update()
    {
        if(GameManager.instance.gamePaused) return;

        if(GetEnemyIDListCount() == penetrationCount) ObjectPool.instance.PoolBullet(gameObject);
        
        curLifeTime += Time.deltaTime;
        if(curLifeTime > lifeTime) ObjectPool.instance.PoolBullet(gameObject);

        transform.Translate(direction * bulletSpeed * Time.deltaTime);
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

    public int GetEnemyIDListCount()
    {
        return damagedEnemyIDList.Count;
    }

    public IWeapon GetAttackWeapon()
    {
        return originWeapon;
    }
}

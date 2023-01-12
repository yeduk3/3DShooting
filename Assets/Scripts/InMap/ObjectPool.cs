using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pooled Object Set
public struct PoolSet
{
    // Object Prefab
    GameObject prefab;
    int amount;
    Transform pool;
    List<GameObject> pooledList;

    public PoolSet(GameObject prefab, int amount, Transform parent)
    {
        this.prefab = prefab;
        this.amount = amount;
        this.pool = parent;
        pooledList = new List<GameObject>();
    }

    public void CreatePool()
    {
        GameObject tmp;

        for(int i = 0; i < amount; i++)
        {
            tmp = GameObject.Instantiate(prefab, pool);
            tmp.SetActive(false);
            pooledList.Add(tmp);
        }
    }

    // Method to Use Pooled Bullet
    public GameObject Pop()
    {
        for(int i = 0; i < amount; i++)
        {
            if(!pooledList[i].activeInHierarchy)
            {
                return pooledList[i];
            }
        }
        return null;
    }

    // Method to Clean Up Bullet
    public void Push(GameObject usedBullet)
    {
        usedBullet.transform.position = pool.position;
        usedBullet.SetActive(false);
    }
}

// Object Pooling
public class ObjectPool : MonoBehaviour
{
    // Use Singleton
    public static ObjectPool instance;

    // For HandGun Bullet
    [Header("HandGun Bullet")]
    public GameObject bulletPrefab;
    public int bulletAmountToPool;
    public Transform bulletPool;
    private PoolSet bulletSet;

    public PoolSet GetBulletSet()
    {
        return bulletSet;
    }

    // For Another..



    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        // Instantiate Objects in Advance
        
        //bulletSet = new PoolSet(bulletPrefab, bulletAmountToPool, bulletPool);
        //bulletSet.CreatePool();
    }
}

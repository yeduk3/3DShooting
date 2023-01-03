using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object Pooling
public class ObjectPool : MonoBehaviour
{
    // Use Singleton
    public static ObjectPool instance;

    // For HandGun Bullet
    [Header("HandGun Bullet")]
    public GameObject bulletPrefab;
    public int bulletAmountToPool;
    public List<GameObject> pooledBullets;
    public Transform bulletPool;

    // For Another..



    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        // Instantiate Objects in Advance
        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < bulletAmountToPool; i++)
        {
            tmp = Instantiate(bulletPrefab, bulletPool);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
    }

    // Method to Use Pooled Object
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < bulletAmountToPool; i++)
        {
            if(!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }

    // Method to Clean Up Bullet
    public void PoolBullet(GameObject usedBullet)
    {
        usedBullet.transform.position = bulletPool.position;
        usedBullet.SetActive(false);
    }
}

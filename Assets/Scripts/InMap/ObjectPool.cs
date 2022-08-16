using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [Header("HandGun Bullet")]
    public GameObject bulletPrefab;
    public int bulletAmountToPool;
    public List<GameObject> pooledBullets;
    public Transform bulletPool;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < bulletAmountToPool; i++)
        {
            tmp = Instantiate(bulletPrefab, bulletPool);
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
    }

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

    public void PoolBullet(GameObject usedBullet)
    {
        usedBullet.transform.position = bulletPool.position;
        usedBullet.SetActive(false);
    }
}

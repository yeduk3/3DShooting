using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{
    public static Armory instance;
    [SerializeField]
    private GameObject[] weapons;
    private Dictionary<string, int> weaponDictionary;

    void Awake()
    {
        // Set singleton
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        weaponDictionary = new Dictionary<string, int>();
        for(int i = 0; i < weapons.Length; i++)
        {
            weaponDictionary.Add(weapons[i].name, i);
            Debug.Log(weapons[i].name + " : " + i);
        }
    }

    public GameObject FindWeapon(string weaponName)
    {
        if(weaponDictionary.TryGetValue(weaponName, out int idx))
        {
            // Debug.Log("Find Weapon: " + weaponName);
            return weapons[idx];
        }
        Debug.LogError("Weapon Not Found");
        return null;
    }
}

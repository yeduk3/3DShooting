using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An Armory for Equip Weapon
public class Armory : MonoBehaviour
{
    // Use Singleton
    public static Armory instance;
    
    // Array of Weapons in this Armory
    [SerializeField]
    private GameObject[] weapons;
    private Dictionary<string, int> weaponDictionary;

    // Make Up Dictionary using GameObject[] weapons
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
        }
    }

    // Method to Pick Up a Weapon
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

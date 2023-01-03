using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponSystem;

public class WeaponHandler : MonoBehaviour
{
    public Transform weaponSpawnPoint;
    public IWeapon equipedWeapon;
    public Text equipedWeaponText;

    // Equip Weapon
    public void EquipWeapon(string weaponName)
    {
        // Remove All Previous Weapons
        Transform[] ts = weaponSpawnPoint.GetComponentsInChildren<Transform>();
        for(int i = 1; i < ts.Length; i++) Destroy(ts[i].gameObject);

        // Pick up a weapon in the armory
        GameObject weaponPrefab = Armory.instance.FindWeapon(weaponName);
        if(weaponPrefab == null) return;

        // Instantiate
        GameObject SpawnedWeapon = GameObject.Instantiate(weaponPrefab, weaponSpawnPoint);
        equipedWeapon = SpawnedWeapon.GetComponent<IWeapon>();
        equipedWeapon.Equiped();

        // Show Weapon Info
        equipedWeaponText.text = weaponName;
        Debug.Log("Equiped Weapon: " + weaponName);
    }

    public void OnEquipWeaponButtonInteraction(string weaponName)
    {
        // Prevent Executed from Another Way
        if(this.GetComponent<EquipWeaponButton>()) return;

        // Execute Equip Weapon(Above Method)
        if(equipedWeapon != null)
        {
            equipedWeapon = null;
        }
        EquipWeapon(weaponName);
    }
}

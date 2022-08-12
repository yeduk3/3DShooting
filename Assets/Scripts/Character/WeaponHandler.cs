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

    public void EquipWeapon(string weaponName)
    {
        Transform[] ts = weaponSpawnPoint.GetComponentsInChildren<Transform>();
        for(int i = 1; i < ts.Length; i++) Destroy(ts[i].gameObject);
        GameObject weaponPrefab = Armory.instance.FindWeapon(weaponName);
        if(weaponPrefab == null) return;
        GameObject SpawnedWeapon = GameObject.Instantiate(weaponPrefab, weaponSpawnPoint);
        equipedWeapon = SpawnedWeapon.GetComponent<IWeapon>();
        equipedWeapon.Equiped();
        equipedWeaponText.text = weaponName;
        Debug.Log("Equiped Weapon: " + weaponName);
        // equipedWeapon.Attack();
    }

    public void OnEquipWeaponButtonInteraction(string weaponName)
    {
        if(equipedWeapon != null)
        {
            equipedWeapon = null;
        }
        EquipWeapon(weaponName);
    }
}

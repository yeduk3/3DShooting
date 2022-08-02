using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public Weapon equipedWeapon;
    public Button swordBtn;
    public Button gunBtn;

    public void EquipWeapon(Weapon _weapon)
    {
        equipedWeapon = _weapon;
        equipedWeapon.Equiped();
        Debug.Log("Equiped Weapon: " + equipedWeapon.GetType());
        equipedWeapon.Attack();
    }

    public void OnBasicSwordButtonClicked()
    {
        if(equipedWeapon != null)
        {
            equipedWeapon = null;
        }
        EquipWeapon(new BasicSword());
    }

    public void OnHandGunButtonClicked()
    {
        if(equipedWeapon != null)
        {
            equipedWeapon = null;
        }
        EquipWeapon(new HandGun());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipWeaponButton : MonoBehaviour
{
    [SerializeField]
    private string buttonMode;
    
    Color origColor;
    WeaponHandler weaponHandler;
    Material material;

    void Start()
    {
        this.material = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseEnter()
    {
        if(this.material.color == Color.green) return;

        Debug.Log("Entered");
        origColor = this.material.color;
        this.material.SetColor("_Color", Color.green);
    }
    

    private void OnMouseExit()
    {
        
        Debug.Log("Exited");
        GetComponent<MeshRenderer>().material.SetColor("_Color", origColor);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked: " + gameObject.name);

        if(weaponHandler == null)
        {
            weaponHandler = GameObject.FindObjectOfType<WeaponHandler>();
        }

        if(buttonMode == "BasicSword")
        {
            weaponHandler.OnBasicSwordButtonClicked();
        }
        else if(buttonMode == "HandGun")
        {
            weaponHandler.OnHandGunButtonClicked();
        }
        else
        {
            Debug.Log("No Weapon to Set");
        }
    }
}

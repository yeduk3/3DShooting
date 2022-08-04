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
    bool isEntered;

    void Start()
    {
        this.material = GetComponent<MeshRenderer>().material;
        isEntered = false;
    }

    private void OnMouseEnter()
    {
        if(this.material.color == Color.green) return;

        // Debug.Log("Entered");
        origColor = this.material.color;
        this.material.SetColor("_Color", Color.green);
        isEntered = true;
    }
    

    private void OnMouseExit()
    {
        
        // Debug.Log("Exited");
        this.material.SetColor("_Color", origColor);
        isEntered = false;
    }

    private void OnInteration()
    {
        // Debug.Log("Clicked: " + gameObject.name);

        if(weaponHandler == null)
        {
            weaponHandler = GameObject.FindObjectOfType<WeaponHandler>();
        }   

        if(buttonMode != "")
        {
            weaponHandler.OnEquipWeaponButtonInteraction(buttonMode);
        }
        else
        {
            Debug.Log("No Weapon to Set");
        }
    }

    void Update()
    {
        if(isEntered && Input.GetKeyDown(KeyCode.G))
        {
            OnInteration();
        }
    }
}

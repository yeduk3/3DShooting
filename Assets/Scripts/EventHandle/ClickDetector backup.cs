using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private string buttonMode;

    private bool focused;
    
    Color origColor;
    WeaponHandler weaponHandler;
    Material material;

    void Start()
    {
        focused = false;
        this.material = GetComponent<MeshRenderer>().material;
    }

    public void OnFocused()
    {
        focused = true;
    }

    public void OnPointerEnter()
    {
        if(this.material.color == Color.green) return;

        Debug.Log("Entered");
        origColor = this.material.color;
        this.material.SetColor("_Color", Color.green);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.material.color == Color.green) return;

        Debug.Log("EDEDEDED Entered");
        origColor = this.material.color;
        this.material.SetColor("_Color", Color.green);
    }
    
    public void OnPointerExit()
    {
        Debug.Log("Exited");
        GetComponent<MeshRenderer>().material.SetColor("_Color", origColor);
    }

    public void OnPointerDown()
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

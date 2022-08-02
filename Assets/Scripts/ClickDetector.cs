using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    private string buttonMode;
    
    Color origColor;
    WeaponHandler wh;

    public void OnPointerEnter(PointerEventData ed)
    {
        Debug.Log("Entered");
        origColor = GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }
    
    public void OnPointerExit(PointerEventData ed)
    {
        Debug.Log("Exited");
        GetComponent<MeshRenderer>().material.SetColor("_Color", origColor);
    }

    public void OnPointerDown(PointerEventData ed)
    {
        Debug.Log("Clicked: " + ed.pointerCurrentRaycast.gameObject.name);

        if(wh == null)
        {
            wh = GameObject.FindObjectOfType<WeaponHandler>();
        }

        if(buttonMode == "BasicSword")
        {
            wh.OnBasicSwordButtonClicked();
        }
        else if(buttonMode == "HandGun")
        {
            wh.OnHandGunButtonClicked();
        }
        else
        {
            Debug.Log("No Weapon to Set");
        }
    }
}

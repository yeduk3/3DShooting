using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponSystem;

public class Enemy : MonoBehaviour
{
    // Slider for show HP of itself.
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Text hpText;

    // HP related values
    [SerializeField]
    private float maxHP;
    private float curHP;

    void Awake()
    {
        hpBar.onValueChanged.AddListener( delegate { OnSliderValueUpdated(); } );

        hpBar.maxValue = maxHP;
        hpBar.minValue = 0;
        hpBar.value = maxHP;
        curHP = maxHP;
        OnSliderValueUpdated();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " Entered");
        if(other.gameObject.CompareTag("Weapon"))
        {
            IWeapon triggeredWeapon = other.transform.parent.parent.parent.GetComponent<WeaponHandler>().equipedWeapon;
            if(triggeredWeapon.IsAttacking())
            {
                curHP = MinusHP(triggeredWeapon.GetDamage());
                
                Debug.Log("Attack in damage " + triggeredWeapon.GetDamage());

                hpBar.value = curHP;
            }
        }
    }

    private float MinusHP(float amount)
    {
        curHP = (curHP - amount > 0f) ? (curHP - amount) : (0f);
        return curHP;
    }

    private float PlusHP(float amount)
    {
        curHP = (curHP + amount < maxHP) ? (curHP + amount) : (maxHP);
        return curHP;
    }

    public void OnSliderValueUpdated()
    {
        hpText.text = curHP.ToString();
    }
}

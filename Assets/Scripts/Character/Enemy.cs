using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponSystem;

public class Enemy : MonoBehaviour
{
    // Information for show HP of itself.
    [Header("HP Info")]
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Text hpText;

    // HP related values
    [Header("HP Data")]
    [SerializeField]
    private float maxHP;
    private float curHP;
    [SerializeField]
    private bool invincible = false;

    private int enemyID;

    void Awake()
    {
        hpBar.onValueChanged.AddListener( delegate { OnSliderValueUpdated(); } );

        hpBar.maxValue = maxHP;
        hpBar.minValue = 0;
        hpBar.value = maxHP;
        curHP = maxHP;
        OnSliderValueUpdated();

        enemyID = gameObject.GetInstanceID();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.CompareTag("Weapon"))
        {
            // IWeapon triggeredWeapon = other.transform.parent.parent.parent.GetComponent<WeaponHandler>().equipedWeapon;
            IDamage triggeredDamage = other.GetComponent<DamageDetector>().GetDetectedDamage();
            IWeapon triggeredWeapon = triggeredDamage.GetAttackWeapon();
            Debug.Log("triggeredWeapon : " + triggeredWeapon.GetName());

            if(!(triggeredDamage.AlreadyBeenDamaged(enemyID)))
            {
                curHP = MinusHP(triggeredWeapon.GetDamage());
                triggeredDamage.DamagedToID(enemyID);

                Debug.Log("Damaged " + triggeredWeapon.GetDamage());

                hpBar.value = curHP;
            }
        }
    }

    private float MinusHP(float amount)
    {
        curHP = (curHP - amount > 0f) ? (curHP - amount) : (invincible) ? (maxHP) : (0f);
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

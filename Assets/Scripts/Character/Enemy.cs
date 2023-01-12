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
    private bool invincible; // if true, not die.

    private int enemyID;

    // Enemy Basic Info(HP, ID) Set
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

    void Start() 
    {
        hpBar.GetComponentInParent<LookTarget>().setTarget(PlayerMove.mainPlayer.transform);
    }

/*
Damage Detect - Collision
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            IDamage triggeredDamage = other.GetComponent<DamageDetector>().GetDetectedDamage();

            if(!(triggeredDamage.AlreadyBeenDamaged(enemyID)) && triggeredDamage.IsDamaging())
            {
                curHP = MinusHP(triggeredDamage.GetDamage());
                triggeredDamage.DamageToEnemyByID(enemyID);
                print(enemyID + " Hitted");

                //Debug.Log("Damaged " + triggeredDamage.GetDamage() + " at " + Time.time);

                hpBar.value = curHP;
            }
        }
    }
*/

    // Damage Detect - Hit Scan
    public void Damaged(float amount)
    {
        curHP = MinusHP(amount);
        hpBar.value = curHP;
    }

    // HP Decrease
    private float MinusHP(float amount)
    {
        curHP = (curHP - amount > 0f) ? (curHP - amount) : (invincible) ? (maxHP) : (0f);
        return curHP;
    }

    // HP Increase
    private float PlusHP(float amount)
    {
        curHP = (curHP + amount < maxHP) ? (curHP + amount) : (maxHP);
        return curHP;
    }

    // HP Text Change
    public void OnSliderValueUpdated()
    {
        hpText.text = curHP.ToString();
    }
}

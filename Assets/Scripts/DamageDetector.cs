using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class DamageDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject detectedDamage;

    public IDamage GetDetectedDamage()
    {
        return detectedDamage.GetComponent<IDamage>();
    }
}

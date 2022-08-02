using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeshDetector : MonoBehaviour
{
    void Start()
    {
        PhysicsRaycaster p = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if(p == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }
}

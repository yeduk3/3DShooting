using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]
    public Transform target;

    void Update()
    {
        // if there's a target to look at,
        if(target != null)
        {
            if(target.CompareTag("Player"))
            {
                // orthogonal looking, suppose that the target has camera
                Vector3 cameraForward = Camera.main.transform.forward;
                //cameraForward.y = 0;
                //transform.LookAt(target, Vector3.up);
                transform.forward = cameraForward;
            }
        }
    }

    // Set the target to be looked
    public void setTarget(Transform target = null)
    {
        this.target = target;
    }
}

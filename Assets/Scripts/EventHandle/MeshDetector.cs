using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MyEventSystems;

public class MeshDetector : MonoBehaviour
{
    Transform cam;
    Ray ray;
    RaycastHit hit;
    MyButton myButton, prevMyButton;
    public string test;

    void Update()
    {
        cam = Camera.main.transform;
        ray = new Ray(cam.position, cam.forward);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(ray.GetPoint(0), ray.direction, Color.red);
            myButton = hit.transform.GetComponent<MyButton>();
            if(myButton != null)
            {
                prevMyButton = myButton;
                myButton.OnSelected();
            }
            else
            {
                if(prevMyButton != null)
                {
                    prevMyButton.eventType = MyEventType.Exit;
                    prevMyButton.OnMyPointerExit();
                    prevMyButton = null;
                }
                
            }
            test = hit.transform.gameObject.name;
        }
    }
}

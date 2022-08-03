using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

//I used ILSpy on the Unity UI dll to copy out the Physicsraycaster code and fix where the ray eminates from (in this case, always the center of the screen)
public class InteractionRaycaster : PhysicsRaycaster {

    [Range(0.0f, 0.5f)]
    public float RayRadius;
    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {

  
        if (this.eventCamera == null)
        {
            return;
        }
        // Debug.Log("Raycasting..");
        Ray ray = this.eventCamera.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height/2f));//this used to be the event position, but when the cursor is locked, that becomes -1,-1 so i fixed it
        // float distance = this.eventCamera.farClipPlane - this.eventCamera.nearClipPlane;
        float distance = Mathf.Infinity;
        RaycastHit[] array = Physics.SphereCastAll(ray, RayRadius, distance, this.finalEventMask);
        Debug.DrawRay(ray.GetPoint(0), ray.direction, Color.red);
        if (array.Length > 1)
        {
            Array.Sort<RaycastHit>(array, (RaycastHit r1, RaycastHit r2) => r1.distance.CompareTo(r2.distance));
        }
        if (array.Length != 0)
        {
            int i = 0;
            int num2 = array.Length;
            while (i < num2)
            {
                RaycastResult item = new RaycastResult
                {
                    gameObject = array[i].collider.gameObject,
                    module = this,
                    distance = array[i].distance,
                    worldPosition = array[i].point,
                    worldNormal = array[i].normal,
                    screenPosition = eventData.position,
                    index = (float)resultAppendList.Count,
                    sortingLayer = 0,
                    sortingOrder = 0
                };
                resultAppendList.Add(item);
                i++;
            }
        }
    
    }
}
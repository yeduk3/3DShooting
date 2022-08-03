using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEventSystems;

public class MyButton : MonoBehaviour, IPointerDetector
{    
    public MyEventType eventType = MyEventType.None;

    public void OnSelected()
    {
        if(eventType == MyEventType.None) 
        {
            eventType = MyEventType.Enter;
            return;
        }
        else if(eventType == MyEventType.Enter)
        {
            this.OnMyPointerEnter();
        }
        else if(eventType == MyEventType.Exit)
        {
            this.OnMyPointerExit();
        }
        else if(eventType == MyEventType.Down)
        {
            this.OnMyPointerDown();
        }
        else if(eventType == MyEventType.Up)
        {
            this.OnMyPointerUp();
        }
    }

    public void OnMyPointerEnter() 
    {
        eventType = MyEventType.Up;
        Debug.Log("PointerDetector.cs: Enter");
    }

    public void OnMyPointerExit() 
    {
        eventType = MyEventType.None;
        Debug.Log("PointerDetector.cs: Exit");
    }

    public void OnMyPointerDown() 
    {
        Debug.Log("PointerDetector.cs: Down");
        eventType = MyEventType.Up;
    }

    public void OnMyPointerUp() 
    {
        // Debug.Log("PointerDetector.cs: Up");
    }

    private void Update() {
        if(eventType == MyEventType.Up && Input.GetMouseButtonDown(0)) {
            eventType = MyEventType.Down;
            OnMyPointerDown();
        }
    }
}




    // private void OnMouseEnter() {
    //     Debug.Log("Test");
    // }

    // private void OnMouseDown() {
    //     Debug.Log("CLick");
    // }
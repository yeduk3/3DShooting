using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.EventSystems;
using Unity.Collections;

public class JobTest : MonoBehaviour
{
    [SerializeField]
    private string buttonMode;

    Color origColor;
    WeaponHandler weaponHandler;
    Material material;
    bool isEntered;

    void Start()
    {
        this.material = GetComponent<MeshRenderer>().material;
        isEntered = false;
    }

    private void OnMouseEnter()
    {
        if (this.material.color == Color.green) return;

        // Debug.Log("Entered");
        origColor = this.material.color;
        this.material.SetColor("_Color", Color.green);
        isEntered = true;
    }


    private void OnMouseExit()
    {

        // Debug.Log("Exited");
        this.material.SetColor("_Color", origColor);
        isEntered = false;
    }

    private void OnInteration()
    {
        NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);
        MyJob jobData = new MyJob();
        jobData.a = 10;
        jobData.b = 12;
        jobData.result = result;

        Debug.Log("Schedule the job");
        JobHandle handle = jobData.Schedule();

        Debug.Log("Wait for the job to complete");
        handle.Complete();
        Debug.Log("Job completed");

        float aPlusB = result[0];
        Debug.LogError("Read Data from Job : " + aPlusB);
        result.Dispose();
    }

    void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.G))
        {
            OnInteration();
        }
    }
}


public struct MyJob : IJob
{
    public float a, b;
    public NativeArray<float> result;
    public void Execute()
    {
        result[0] = a + b;
        Debug.LogError("Job Excuted, Test Value = " + result[0]);
    }
}
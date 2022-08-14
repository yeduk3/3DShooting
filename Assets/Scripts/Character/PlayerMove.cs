using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float rotateSpeed = 2f;

    [SerializeField]
    Transform playerCamera;

    private bool canJump = false;

    void Awake()
    {
        moveSpeed = walkSpeed;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the game should stop, no update for character move
        if(GameManager.instance.gamePaused) return;

        if(Input.GetKey(KeyCode.LeftShift)) moveSpeed = runSpeed;
        else moveSpeed = walkSpeed;

        // XZ Plane Character Movement
        float moveSpeedPerFrame = moveSpeed * Time.deltaTime;
        float horz = Input.GetAxis("Horizontal") * moveSpeedPerFrame;
        float vert = Input.GetAxis("Vertical") * moveSpeedPerFrame;

        transform.Translate(new Vector3(horz, 0, vert));

        // XYZ Character & Camera Rotation
        float rotateSpeedPerFrame = rotateSpeed * Time.deltaTime;
        horz = Input.GetAxis("Mouse X") * rotateSpeed;
        vert = Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + horz, 0f);
        playerCamera.eulerAngles = new Vector3(playerCamera.eulerAngles.x-vert, transform.eulerAngles.y, 0f);

        // Jump
        if(canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(vel.x, 10f, vel.z);
        }

        // Position & Rotation Reset
        if(Input.GetKeyDown(KeyCode.T))
        {
            transform.position = new Vector3(3.04f, 1.77f, 1f);
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}

using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference
    Rigidbody playerRb;
    public float moveSpeed = 0.2f;
    public float moveSpeedAngle = 0.5f;
    public float moveSpeedRollAngle = 0.05f;
    private float verticalMove;
    private float horizontalMove;
    private float mouseInputX;
    private float mouseInputY;
    private float rollInput;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");
        
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        // WASD Input
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * moveSpeed, ForceMode.VelocityChange);
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.right) * horizontalMove * moveSpeed, ForceMode.VelocityChange);
        
        // Roll Input
        playerRb.AddTorque(playerRb.transform.right * moveSpeedAngle * mouseInputY * -1, ForceMode.VelocityChange);
        playerRb.AddTorque(playerRb.transform.up * moveSpeedAngle * mouseInputX, ForceMode.VelocityChange);
        
        playerRb.AddTorque(playerRb.transform.forward * moveSpeedRollAngle * rollInput, ForceMode.VelocityChange);

    }
}

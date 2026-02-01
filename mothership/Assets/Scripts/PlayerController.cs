using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference
    private Rigidbody playerRb;
    private float moveSpeed = 0.2f;
    private float moveSpeedAngle = 0.5f;
    private float moveSpeedRollAngle = 0.05f;
    private float verticalMove;
    private float horizontalMove;
    private float mouseInputX;
    private float mouseInputY;
    private float rollInput;

    private float boostSpeed = 100.0f;

    public bool isDocked;
    public bool isDocking = false;

    public AudioSource damageAudio;
    
    public GameManager gameManager;
    
    public Vector3 originalPosition;
    
    public AudioSource repairAudio;
    public AudioSource dockingAudio;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // mouse pointer locked to centre 
        playerRb = GetComponent<Rigidbody>();
        originalPosition = gameObject.transform.position;   // player object is in start position
    }


    private void FixedUpdate()
    {
        // WASD Input
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * moveSpeed,
            ForceMode.VelocityChange);
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.right) * horizontalMove * moveSpeed,
            ForceMode.VelocityChange);

        // Roll Input
        playerRb.AddTorque(playerRb.transform.right * moveSpeedAngle * mouseInputY * -1, ForceMode.VelocityChange);
        playerRb.AddTorque(playerRb.transform.up * moveSpeedAngle * mouseInputX, ForceMode.VelocityChange);

        playerRb.AddTorque(playerRb.transform.forward * moveSpeedRollAngle * rollInput, ForceMode.VelocityChange);
        
        if (Input.GetKey(KeyCode.F) && !isDocked)                       // if player is not docked & F is pressed, boost speed is added to player speed
        {
            playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * moveSpeed * boostSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isDocked)                // if player is docked and space is pressed, player is no longer docked
        {
            isDocked = false;
        }
        
        if (!isDocked)                                                  // if player is not docked, movement can take place
        {
            verticalMove = Input.GetAxis("Vertical");
            horizontalMove = Input.GetAxis("Horizontal");
            rollInput = Input.GetAxis("Roll");
                                                                                                          
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");

        }
        
        if (isDocking && Input.GetKey(KeyCode.Space))                   // if player is docking and space is pressed, player is docked
        {
            isDocked = true;
            isDocking = false;
        }

        if (isDocked)
        {
            
            playerRb.transform.position = originalPosition;             // if docked, player returns to initial position
 
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DockingArea") && !isDocked)               // if player is in docking area and is not docked
        {
            if (Input.GetKey(KeyCode.Space))                            // if space is pressed
            {       
                isDocking = true;                                       // player is docking, audio plays
                repairAudio.Play();
                dockingAudio.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))                // if player collides with asteroid, audio plays, player health is reduced
        {
            damageAudio.Play();
            gameManager.RemoveHealth(10);

        }
    }
}
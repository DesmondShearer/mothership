using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
        originalPosition = gameObject.transform.position;
    }
    
    void Update()
    {
        
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
        
        if (Input.GetKey(KeyCode.F) && !isDocked)
        {
            playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * moveSpeed * boostSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isDocked)
        {
            isDocked = false;
        }
        
        if (!isDocked)
        {
            verticalMove = Input.GetAxis("Vertical");
            horizontalMove = Input.GetAxis("Horizontal");
            rollInput = Input.GetAxis("Roll");
                                                                                                          
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");
        }
        
        if (isDocking && Input.GetKey(KeyCode.Space))
        {
            isDocked = true;
            isDocking = false;
        }

        if (isDocked)
        {
            playerRb.transform.position = originalPosition;
        }

    }

    // on tigger ENTER vs EXIT - adjust bools
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DockingArea") && !isDocked)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isDocking = true;
                repairAudio.Play();
                dockingAudio.Play();
            }
        }
    }

    // move to asteroid
    // player health script
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            damageAudio.Play();
            gameManager.RemoveHealth(10);
            // particle effect
        }
    }
}
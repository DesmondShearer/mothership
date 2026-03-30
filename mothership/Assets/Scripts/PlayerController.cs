using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody playerRb;
    
    public PlayerStatManager playerStatManager;
    public PlayerStat moveSpeed;
    public PlayerStat boostSpeed;
    
    private float moveSpeedAngle = 0.5f;
    private float moveSpeedRollAngle = 0.05f;
    //private float boostSpeed = 100f;
    
    private float verticalMove;
    private float horizontalMove;
    private float mouseInputX;
    private float mouseInputY;
    private float rollInput;
    
    public bool isDocked;
    public bool isDocking = false;

    public AudioSource damageAudio;
    
    public GameManager gameManager;
    
    public Vector3 originalPosition;
    
    public AudioSource repairAudio;
    public AudioSource dockingAudio;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerRb = GetComponent<Rigidbody>();
        originalPosition = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * playerStatManager.GetStatValue(moveSpeed),
            ForceMode.VelocityChange);
        playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.right) * horizontalMove * playerStatManager.GetStatValue(moveSpeed),
            ForceMode.VelocityChange);

        
        playerRb.AddTorque(playerRb.transform.right * moveSpeedAngle * mouseInputY * -1, ForceMode.VelocityChange);
        playerRb.AddTorque(playerRb.transform.up * moveSpeedAngle * mouseInputX, ForceMode.VelocityChange);

        playerRb.AddTorque(playerRb.transform.forward * moveSpeedRollAngle * rollInput, ForceMode.VelocityChange);
        
        if (Input.GetKey(KeyCode.F) && !isDocked)
        {
            playerRb.AddForce(playerRb.transform.TransformDirection(Vector3.forward) * verticalMove * playerStatManager.GetStatValue(moveSpeed) * playerStatManager.GetStatValue(boostSpeed));
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            damageAudio.Play();
            gameManager.RemoveHealth(10);
        }
    }
}
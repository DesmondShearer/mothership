
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Shoot : MonoBehaviour
{
    
    public Camera playerCamera;
    public Transform laserOrigin;
    public LineRenderer laserLine;
    public AudioSource laserSound;
    
    public float laserRange = 100f;
    public float laserDamage = 20f;
    
    public float fireRate = 0.25f;
    public bool canFire = true;
    
    public GameManager gameManager;
    public ParticleSystem hitParticles;
    public PlayerController playerController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       laserLine = GetComponentInChildren<LineRenderer>();
       laserSound = GetComponentInChildren<AudioSource>();
       playerCamera = GetComponentInChildren<Camera>();
       
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameManager.gameOverCheck)                         // if game is NOT over
        {
            if (!playerController.isDocked)                     // if player is NOT docked
            {
                if (Input.GetMouseButtonDown(0) && canFire)     // if left mouse button is pressed and firing is allowed
                {
                    StartCoroutine(ShootLaser());               // shoot laser
                }
            }
        }

              
        Debug.DrawRay(laserOrigin.position, laserOrigin.transform.forward*laserRange, Color.red);   
              
      
    }

    private IEnumerator ShootLaser()
    {
        canFire = false;                                // if laser is being fired, it cannot fire again
        Fire();                                         // run laser fire method
        laserSound.Play();                              // play sound
        laserLine.enabled = true;                       // enable visual line
        yield return new WaitForSeconds(fireRate);      //fire for determined time
        laserLine.enabled = false;                      // switch off visual line    
        canFire = true;                                 // allow firing again
    }   

    void Fire()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        laserLine.SetPosition(0, laserOrigin.position);
 
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, laserRange))    // if laser hits asteroid
        {
            laserLine.SetPosition(1, hit.point);
            Target health = hit.collider.GetComponent<Target>();                                // get health of target
            Target points = hit.collider.GetComponent<Target>();                                // get point value of target
            
            if (health != null)                                                                 // if target health is not null
            {
                gameManager.UpdateScore(points.points);                                         // increase points
                health.TakeDamage(laserDamage);                                                 // remove health from target by laser damage amount (using take damage method on target)
                Instantiate(hitParticles,hit.point,Quaternion.identity);                        // generate particles to show hit
            }
                
        }
        else
        {
            laserLine.SetPosition(1,rayOrigin + (playerCamera.transform.forward * laserRange));   // otherwise, just fire the laser from the origin
                                                                                                    // as far as the range is set
        }
    }
}

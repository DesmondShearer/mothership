
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       laserLine = GetComponentInChildren<LineRenderer>();
       laserSound = GetComponentInChildren<AudioSource>();
       playerCamera = GetComponentInChildren<Camera>();
       
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       //hitParticles = GameObject.Find("Sparks").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(laserOrigin.position, laserOrigin.transform.forward*laserRange, Color.red);
        
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(ShootLaser());
        }
    }

    private IEnumerator ShootLaser()
    {
        canFire = false;
        Fire();
        laserSound.Play();
        laserLine.enabled = true;
        yield return new WaitForSeconds(fireRate);
        laserLine.enabled = false;
        canFire = true;
    }

    void Fire()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        laserLine.SetPosition(0, laserOrigin.position);
 
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, laserRange))
        {
            laserLine.SetPosition(1, hit.point);
            Target health = hit.collider.GetComponent<Target>();
            Target points = hit.collider.GetComponent<Target>();
            
            if (health != null)
            {
                gameManager.UpdateScore(points.points);
                health.TakeDamage(laserDamage);
                Instantiate(hitParticles,hit.point,Quaternion.identity);
            }
                
        }
        else
        {
            laserLine.SetPosition(1,rayOrigin + (playerCamera.transform.forward * laserRange));
        }
    }
}

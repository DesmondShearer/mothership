
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioSource laserSound;
    
    public Camera laserCamera;

    public float laserDamage = 20f;
    public float laserRange = 100f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        laserSound.Play();
        RaycastHit hit;
        if(Physics.Raycast(laserCamera.transform.position, laserCamera.transform.forward, out hit, laserRange))
        {
           Target target = hit.transform.GetComponent<Target>();
           if (target !=null)
           {
               target.TakeDamage(laserDamage);
           }
        }
    }

}

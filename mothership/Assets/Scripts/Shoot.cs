
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioSource laserSound;
    public Transform firePoint;
    public GameObject laser;
    public GameObject hitPoint;
    public Camera laserCamera;
    
    
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
        RaycastHit hit;
        laserSound.Play();
        if(Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            GameObject a = Instantiate(laser, firePoint.position, Quaternion.identity);
            GameObject b = Instantiate(hitPoint, hit.point, Quaternion.identity);
            
            Destroy(a,1);
            Destroy(b,1);
        }
    }

}

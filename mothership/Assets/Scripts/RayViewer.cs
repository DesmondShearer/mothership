using UnityEngine;

public class RayViewer : MonoBehaviour
{

    public float weaponRange = 50f;
    
    private Camera playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, playerCamera.transform.forward*weaponRange, Color.green);
    }
}

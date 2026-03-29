using UnityEngine;

public class RayViewer : MonoBehaviour
{

    public float weaponRange = 50f;
    
    private Camera playerCamera;
    void Start()
    {
        playerCamera = GetComponentInParent<Camera>();
    }
    
    void Update()
    {
        Vector3 lineOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, playerCamera.transform.forward*weaponRange, Color.green);
    }
}

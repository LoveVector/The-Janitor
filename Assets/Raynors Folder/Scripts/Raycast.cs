using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    public GameObject fire;
    int range = 10;

    Vector3 startPoint;
    
    void Start()
    {
        startPoint = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(startPoint, camera.transform.forward * 10f);
    }
}

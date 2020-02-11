using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    public GameObject fire;
    int range = 10;

    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = camera.WorldToViewportPoint(new Vector3(0.5f, 0.5f, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(fire.transform.position, endPoint);
    }
}

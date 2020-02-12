using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Guns
{
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(startPoint, cam.transform.forward * range);
        Fire();
    }
}

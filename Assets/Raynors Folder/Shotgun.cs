using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Guns
{
    public GameObject firePoint2;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public override void Fire()
    {

        Vector3 startPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Input.GetMouseButtonDown(0) && Time.time >= lastShot)
        {
            lastShot = Time.time + fireRate;
            RaycastHit hit;
            if (Physics.Raycast(startPoint, cam.transform.forward, out hit, range))
            {
                Debug.Log("Shot");
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                bulletScript.target = hit.point;
                GameObject newBull2 = Instantiate(bullet, firePoint2.transform.position, firePoint2.transform.rotation);
                bulletScript = newBull2.GetComponent<BulletScript>();
                bulletScript.target = hit.point;
                anim.SetTrigger("Fire");
            }
            else
            {
                Debug.Log("Hit");
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                bulletScript.target = (startPoint + cam.transform.forward * range) + Vector3.right;
                GameObject newBull2 = Instantiate(bullet, firePoint2.transform.position, firePoint2.transform.rotation);
                bulletScript = newBull2.GetComponent<BulletScript>();
                bulletScript.target = (startPoint + cam.transform.forward * range) + Vector3.left;
                anim.SetTrigger("Fire");
            }
        }
    }
}

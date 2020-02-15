using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    public int damage;
    public float range;
    public float fireRate;
    protected float lastShot = 0;

    protected Animator anim;

    public GameObject firePoint;
    public GameObject bullet;

    protected BulletScript bulletScript;

    protected int enemyLayer;
    public Camera cam;

    public virtual void Fire()
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
                anim.SetTrigger("Fire");
            }
            else
            {
                Debug.Log("Hit");
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                bulletScript.target = startPoint + cam.transform.forward * range;
                anim.SetTrigger("Fire"); 
            }
        }
    }
}
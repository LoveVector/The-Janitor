using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submachine : Guns
{
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

        if(Input.GetMouseButton(0))
        {
            anim.SetBool("Fire1", true);
            if (Time.time >= lastShot)
            {
                lastShot = Time.time + fireRate;
                RaycastHit hit;
                if (Physics.Raycast(startPoint, cam.transform.forward, out hit, range))
                {
                    Debug.Log("Shot");
                    GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    bulletScript = newBull.GetComponent<BulletScript>();
                    bulletScript.target = hit.point;
                }
                else
                {
                    Debug.Log("Hit");
                    GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    bulletScript = newBull.GetComponent<BulletScript>();
                    bulletScript.target = startPoint + cam.transform.forward * range;
                }
            }
        }
        else
        {
            anim.SetBool("Fire1", false);
        }
    }
}

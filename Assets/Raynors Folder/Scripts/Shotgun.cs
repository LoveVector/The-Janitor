using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Guns
{
    public GameObject firePoint2;
    BulletScript bulletScript2;  
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        anim = GetComponent<Animator>();

        ammo = beginningAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();
    }

    public override void Fire()
    {

        Vector3 startPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Input.GetMouseButtonDown(0) && Time.time >= lastShot && ammo > 0)
        {
            ammo--;
            Debug.Log(firePoint.transform.position.z + " " + firePoint2.transform.position.z);
            lastShot = Time.time + fireRate;
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                GameObject newBull2 = Instantiate(bullet, firePoint2.transform.position, firePoint2.transform.rotation);
                bulletScript2 = newBull2.GetComponent<BulletScript>();
                if (firePoint.transform.position.z >= firePoint2.transform.position.z)
                {
                    bulletScript.target = (startPoint + cam.transform.forward * range) + Vector3.left * 5;
                    bulletScript2.target = (startPoint + cam.transform.forward * range) + Vector3.right * 5;
                }
                else
                {
                    bulletScript.target = (startPoint + cam.transform.forward * range) + Vector3.right * 5;
                    bulletScript2.target = (startPoint + cam.transform.forward * range) + Vector3.left * 5;
                }
                anim.SetTrigger("Fire");
            }
        }
    }
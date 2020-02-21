using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submachine : Guns
{
    float recoilY = 0;
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
    }

    public override void Fire()
    {
        Vector3 startPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if(Input.GetMouseButton(0) && ammo > 0)
        {
            anim.SetBool("Fire1", true);
            if (Time.time >= lastShot)
            {
                ammo--;
                recoilY += 0.4f;
                lastShot = Time.time + fireRate;
                RaycastHit hit;
                if (Physics.Raycast(startPoint, cam.transform.forward + new Vector3(0, recoilY, 0), out hit, range))
                {
                    GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    bulletScript = newBull.GetComponent<BulletScript>();
                    bulletScript.target = hit.point + new Vector3(0, recoilY, 0);
                }
                else
                {
                    GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    bulletScript = newBull.GetComponent<BulletScript>();
                    bulletScript.target = startPoint + (cam.transform.forward * range) + new Vector3(0, recoilY, 0);
                }
            }
        }
        else
        {
            recoilY = 0;
            anim.SetBool("Fire1", false);
        }
    }
}

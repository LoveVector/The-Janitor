﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    public int damage;
    protected int ammo;
    public int ammoCap;
    public int beginningAmmo;

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

        if (Input.GetMouseButtonDown(0) && Time.time >= lastShot && ammo > 0)
        {
            ammo--;
            anim.SetTrigger("Fire");
            lastShot = Time.time + fireRate;
            RaycastHit hit;
            if (Physics.Raycast(startPoint, cam.transform.forward, out hit, range))
            {
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                bulletScript.target = hit.point;
            }
            else
            {
                GameObject newBull = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                bulletScript = newBull.GetComponent<BulletScript>();
                bulletScript.target = startPoint + cam.transform.forward * range; 
            }
        }
    }

    public virtual void Reload()
    {
        if (ammo == 0 && ammoCap > 0)
        {
            if(ammoCap >= beginningAmmo)
            {
                ammo = beginningAmmo;
                ammoCap -= beginningAmmo;
            }
            else
            {
                ammo = ammoCap;
                ammoCap -= ammoCap;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    public int damage;
    public float range;
    public float fireRate;
    float lastShot;

    public GameObject firePoint;
    public Camera cam;

    public virtual void Fire()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastShot >= fireRate)
        {

        }
    }
}

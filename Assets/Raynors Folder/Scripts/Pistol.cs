using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Guns
{
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

    public override void Reload()
    {
        if(ammo == 0)
        {
            ammo = beginningAmmo;
        }
    }
}

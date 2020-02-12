using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public GameObject hand;
    public Weapon myWeapon;
    Animator handAnim;

    float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        handAnim = hand.GetComponentInChildren<Animator>();
        myWeapon = hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackMelee();
    }

    void AttackRayCast()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, myWeapon.attackRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("EnemyHitWithMelee");
            }
        }

    }

    void AttackMelee()
    {
        attackTimer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            handAnim.Play("AttackMeleeHammer");
        }
        if(Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            attackTimer = 0f;
            AttackRayCast();
        }
    }
}

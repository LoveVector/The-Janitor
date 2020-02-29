using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeEnemey : EnemyAbstract
{
    enum state { chasing, attacking, dead}
    state enemyState;

    public RaycastHit hit;

    public GameObject model;

    bool deadForce;
    // Start is called before the first frame update
    void Start()
    {
        enemyState = state.chasing;

        anim = GetComponent<Animator>();

        rb = model.GetComponent<Rigidbody>();

        deadForce = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        if (dead != true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= 2)
            {
                enemyState = state.chasing;
            }
            else
            {
                enemyState = state.attacking;
            }
        }
        else
        {
            enemyState = state.dead;
        }

        switch (enemyState)
        {
            case state.chasing:
                Chasing();
                break;
            case state.attacking:
                Attacking();
                break;
            case state.dead:
                anim.enabled = false;
                if (deadForce == false)
                {
                    rb.AddForce(-hit.normal * 100);
                    deadForce = true;
                }
                break;
            default:
                break;
        }
    }

    void HealthCheck()
    {
        if(health <= 0)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
    }

    void Chasing()
    {
        Debug.Log("Doing");
        Vector3 distance = (player.transform.position - transform.position).normalized;
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.position += distance * speed * Time.deltaTime;
    }

    void Attacking()
    {
        Debug.Log("This");
        if (Time.time - lastAttack >= attackRate)
        {
            lastAttack = Time.time + attackRate;
            int attackType = Random.Range(0, 2);
            anim.SetFloat("AttackBlend", attackType);
            anim.SetTrigger("Attack");
        }
    }
}
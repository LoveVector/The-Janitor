using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public int health;
    public int attackDamage;
    public int bulletLayer;

    public float attackRate;
<<<<<<< HEAD
    public float runSpeed;
=======
    public float lastAttackTime;
    public float runSpeed;
    public float injuredSpeed;
>>>>>>> CoolerKyleBranch
    public float lastAttack;

    public float speed;

    public bool dead = false;
<<<<<<< HEAD
=======
    public bool surrender = false;
>>>>>>> CoolerKyleBranch

    public Animator anim;

    public GameObject player;

    public Rigidbody rb;

    void Start()
    {
        bulletLayer = LayerMask.NameToLayer("PlayerBullet"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD

    public virtual void Damage(int damage)
    {
        Debug.Log("Damaged");
        health -= damage;
=======
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("this");
        if (other.gameObject.layer == bulletLayer)
        {
            health -= 10;
        }
>>>>>>> CoolerKyleBranch
    }
}

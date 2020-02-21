using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public int health;
    public int attackDamage;
    public int bulletLayer;

    public float attackRate;
    public float lastAttackTime;
    public float runSpeed;
    public float injuredSpeed;
    public float lastAttack;

    public float speed;

    public bool dead = false;
    public bool surrender = false;

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
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("this");
        if (other.gameObject.layer == bulletLayer)
        {
            health -= 10;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float despawnTime;

<<<<<<< HEAD
    public int damage;

    public Vector3 target;
    Vector3 movement;

    public RaycastHit hit;

    int enemyLayer;
=======
    public Vector3 target;
    Vector3 movement;

    int bulletLayer;
>>>>>>> CoolerKyleBranch

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        enemyLayer = LayerMask.NameToLayer("Enemy");
=======
        bulletLayer = LayerMask.NameToLayer("Bullet");
>>>>>>> CoolerKyleBranch
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
        //Vector3 norm = (target - transform.position).normalized;
        //Vector3 distance = (target - transform.position);
        //if (distance.magnitude <= norm.magnitude)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    rb.velocity = (target - transform.position).normalized * speed * Time.deltaTime;
        //}

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.layer == enemyLayer)
        {
            BasicMeleeEnemey basic = other.gameObject.GetComponentInParent<BasicMeleeEnemey>();
            basic.hit = hit;
            basic.Damage(damage);
        }
            Destroy(this.gameObject);
=======
    { 
        rb.velocity = (target - transform.position).normalized * speed * Time.deltaTime;

        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != bulletLayer)
        {
            Destroy(this.gameObject);
        }
>>>>>>> CoolerKyleBranch
    }
}

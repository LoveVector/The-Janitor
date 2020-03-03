using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float despawnTime;

    public int damage;

    public Vector3 target;
    Vector3 movement;

    public RaycastHit hit;

    int enemyLayer;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
        Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.layer == enemyLayer)
        {
            EnemyAbstract basic = other.gameObject.GetComponentInParent<EnemyAbstract>();
            basic.hit = hit;
            basic.Damage(damage);
        }
            Destroy(this.gameObject);
    }
}

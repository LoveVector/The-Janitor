using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float despawnTime;

    public Vector3 target;
    Vector3 movement;

    int bulletLayer;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        bulletLayer = LayerMask.NameToLayer("Bullet");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
    }
}

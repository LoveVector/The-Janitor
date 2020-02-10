using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    public float speed;
    public float runSpeed;
    public float walkSpeed;
    bool running = false;
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0.0f;


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            speed = runSpeed;
            print("Running");
        }
        else
        {
            running = false;
            speed = walkSpeed;
            print("walking");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}

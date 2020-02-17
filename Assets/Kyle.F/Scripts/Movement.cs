using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 movement;
    Vector3 slideDir;

    public float speed;
    public float dashT;
    public float dashSp;
    public float jumpH;
    public float slideTime;

    bool crouch = false;
    bool isGrounded;
    bool sliding = false;

    Animator anim;
    public Animator collidanim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }        
    }

    void FixedUpdate()
    {
        Move();

        if (isGrounded = true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpH, rb.velocity.z);
            Debug.Log("Jumping");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());  
        }

        if(Input.GetKey(KeyCode.C))
        {
            sliding = true;
            slideDir = transform.TransformDirection(movement);
            //crouch = true;
            slideTime -= Time.deltaTime;
            //anim.SetBool("isCrouching", true);
            //collidanim.SetBool("isCrouched", true);
            rb.velocity = slideDir;
            if (slideTime <= 0)
            {
                sliding = false;
            }
            Debug.Log("sliding");
        }
        else
        {
            sliding = false;
            slideTime = 3.0f;
            //anim.SetBool("isCrouching", false);
            //collidanim.SetBool("isCrouched", false);
            //crouch = false;
        }
    }

    IEnumerator Dash()
    {
        rb.velocity = movement * dashSp;
        yield return new WaitForSeconds(dashT);
        Debug.Log("Dashing");
    }

    void Move()
    {
        movement = Quaternion.Euler(0, rb.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
        rb.velocity = movement;

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //movement = new Vector3(h, rb.velocity.y, v);
        //movement = movement.normalized;
        //movement = transform.TransformDirection(movement);

        //Vector3 pvelocity = movement * speed * Time.deltaTime;
        //rb.velocity = movement;

        //movement = cameraTransform.TransformDirection(movement);
        //movement.y = 0.0f;
    }

    void Crouch()
    {
        if (crouch == false)
        {
                crouch = true;
                anim.SetBool("isCrouching", true);
                collidanim.SetBool("isCrouched", true);
                float slideForce = 400;
                rb.AddForce(transform.forward * slideForce);
                //anim.SetBool("isRunning", false);
        }
        else
        {
            crouch = false;
            anim.SetBool("isCrouching", false);
            collidanim.SetBool("isCrouched", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

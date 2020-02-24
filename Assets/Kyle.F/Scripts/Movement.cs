using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 movement;
    Vector3 slideDir;

    public Transform player;

    public LayerMask groundLayer;

    public float speed;
    public float wSpeed;
    public float dashT;
    public float dashSp;
    public float jumpH;
    public float slideSpeed;
    public float slideTime;
    public float slideTimeMax;

    bool crouching = false;
    bool isGrounded;
    bool sliding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 20, groundLayer);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCrouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopCrouch();
        }

        if (!isGrounded)
        {
            Debug.Log("Hitting ground");
        }
    }

    void FixedUpdate()
    {
        Move();

        if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpH, rb.velocity.z);
            Debug.Log("Jumping");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());  
        }

        if(!sliding && Input.GetKeyDown(KeyCode.C))
        {
            //sliding = true;
            //speed = slideSpeed;

            //if(sliding)
            //{
            //    slideTime = 0.0f;
            //    //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            //    transform.localScale = new Vector3(1, 0.7f, 1);
            //    speed = slideSpeed;
            //    rb.velocity = transform.forward * slideSpeed;

            //    slideTime += Time.deltaTime;

            //    if(slideTime > slideTimeMax)
            //    {
            //        sliding = false;
            //    }
            //}
            //slideDir = transform.TransformDirection(movement);
            //crouch = true;
            //slideTime -= Time.deltaTime;
            //anim.SetBool("isCrouching", true);
            //collidanim.SetBool("isCrouched", true);
            //rb.velocity = slideDir;
            //if (slideTime <= 0)
            Debug.Log("sliding");
        }
        else
        {
            sliding = false;
            //slideTime = 3.0f;
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
        speed = wSpeed;
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
        //if (crouching == false)
        //{
        //        crouch = true;
        //        //anim.SetBool("isCrouching", true);
        //        //collidanim.SetBool("isCrouched", true);
        //        //anim.SetBool("isRunning", false);
        //}
        //else
        //{
        //    crouch = false;
        //    //anim.SetBool("isCrouching", false);
        //    //collidanim.SetBool("isCrouched", false);
        //}
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

    private void OnDrawGizmos()
    {
        //RaycastHit hit;
        //Physics.SphereCast(jumpChecker.position, radius, Vector3.down, out hit, 20, groundLayer);
    }

    void StartCrouch()
    {
        //float slideForce = 400;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        transform.localScale = new Vector3(1, 0.7f, 1);
        crouching = true;

        //if(rb.velocity.magnitude > 0.5f)
        //if (isGrounded)
        //{
        //        rb.velocity = player.transform.forward * slideForce;
        //}

        //if (crouching)
        //{
        //    rb.AddForce(speed * Time.deltaTime * -rb.velocity.normalized * slideCounterMovement);
        //    return;
        //}
    }

    void StopCrouch()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
}

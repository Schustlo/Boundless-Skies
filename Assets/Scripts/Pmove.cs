using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PMove : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float jumpheight;
    public CustomGravity cg;

    private float xmov;
    private float zmov;
    private bool jumpTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {
        xmov = Input.GetAxisRaw("Horizontal");
        zmov = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpTrigger = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement
        rb.velocity = new Vector3(xmov * speed, rb.velocity.y, zmov * speed);

        //jumping
        if (jumpTrigger)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpheight, rb.velocity.z);
            jumpTrigger = false;
        }

        // if (isGrounded() && Input.GetButtonDown("Jump"))
        // {
        //     cg.gravityScale *= -1;
        // }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("grav"))
        {
            SwitchGravity();
        }
    }

    void SwitchGravity()
    {
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        cg.gravityScale *= -1;
    }

}



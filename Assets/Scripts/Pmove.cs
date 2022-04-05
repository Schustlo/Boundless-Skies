using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmove : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float jumpheight;
    public CustomGravity cg;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        float xmov = Input.GetAxisRaw("Horizontal");
        float zmov = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xmov * speed, rb.velocity.y, zmov * speed) ;

        //jumping
         if(isGrounded()&& Input.GetButtonDown("Jump"))
         {
             rb.velocity = Vector3.up * jumpheight;
         }
        

        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
           // cg.gravityScale *= -1;
        }
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
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

}

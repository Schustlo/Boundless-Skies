using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity ;
    public float jumpHeight = 3;
    Vector3 velocity;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public float rote = 180;

    float horizontal;
float vertical;
    public float orgset =2f;
    public float curset;
    public int coins = 5;
    public bool stayed = true;

    // Update is called once per frame
    void Update()
    {

        //gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //jump
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;

        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            isGrounded = false;
        }

       
        //walk
         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetAxisRaw("Vertical");
        cam.transform.Rotate(Vector3.up * horizontal/5);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }





    }

    IEnumerator jumpdelay()
    {
        yield return new WaitForSeconds(3);
    }



        void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("death"))
        {
            SceneManager.LoadScene("start");
        }


    }

    void OnCollisionStay(Collision col)
    {
        if (stayed == true)
        {
            if (col.gameObject.CompareTag("ground"))
            {
                jumpdelay();
                isGrounded = true;

            }
            jumpdelay();
            stayed = true;
        }
    }


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("grav"))
        {
            gravity = gravity * -1;
            jumpHeight = jumpHeight * 1;
            transform.Rotate(Vector3.right * rote);
            cam.transform.Rotate(Vector3.back * rote);


        }

        if (col.gameObject.CompareTag("check")&& coins==5)
        {
            SceneManager.LoadScene("start");
        }

    }



}

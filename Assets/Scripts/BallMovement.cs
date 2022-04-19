using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    /*TIPS FROM PROFESSOR TONGUE
     * You should use the rigidbody in the FixedUpdate Function 
     * In unity Y is Up in space, and Z is back and foward in space
     * 
     */
    [SerializeField]
    private float ballspeed = 5f;
    private bool unground = false; 
    private bool calculatePhysics = false;
    private Vector3 force = Vector3.zero;
    private InputControllers input;
    private new Rigidbody rigidbody;
    [SerializeField]
    private float jumpfloat = 2f; 


    #region UNITY API FUNCTIONS
    void Awake()
    {
        input = FindObjectOfType<InputControllers>();
        if(input == null)
        {

            Debug.LogError("Hello Unity Student, this is Professor Tongue! I am giving you this error because, I can't find the InputControllers script in your Unity Scene.");
               
        }
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.LogError("Hello Unity Student, this is Professor Tongue! I am giving you this error because, I can't find the Rigidbody on your ball gameobject");
               
        }
    }

    //DO NOT WORRY ABOUT THIS
    void OnEnable()
    {
        TurnOnInputEvents();

    }
    //DO NOT WORRY ABOUT THIS
    private void OnDisable()
    {

        TurnOffInputEvents();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) 
        {
            unground = false;
               
        }
    }
    private void FixedUpdate()
    {
        if (calculatePhysics == true)
        {
           
            rigidbody.AddForce(force * ballspeed);                             

            calculatePhysics = false;
        }
    }
    #endregion

    #region Private

    private void Jump()
    { 
        if (unground == false)
        {
            unground = true;
        rigidbody.AddForce(Vector3.up * jumpfloat, ForceMode.Impulse);
        } 

             

    }

    private void MovementHorizontal(float value)
    {
        //TODO: Do handle Horizontal movement HERE
        force.x = value;
        calculatePhysics = true;

    }


    private void MovementVertical(float value)
    {
        //TODO: Do handle Vertical movement HERE
        //What is the difference between Vertical MOVEMENT and Vertical INPUT
        // Vertical MOVEMENT is going up and down
        // FORWARD MOVEMENT is going forwards and backwards
        // You give a game vertical input by USING A CONTROLLER by moving the control stick up and down
        // You are reading vertical INPUT to have forward MOVEMENT
        force.z = value;
        calculatePhysics = true;



    }


    //DO NOT WORRY ABOUT THIS
    private void TurnOnInputEvents()
    {
        input.Jump += Jump;
        input.AxisX += MovementHorizontal;
        input.AxisY += MovementVertical;
    }

    //DO NOT WORRY ABOUT THIS
    private void TurnOffInputEvents()
    {
        input.Jump -= Jump;
        input.AxisX -= MovementHorizontal;
        input.AxisY -= MovementVertical;
    }
    #endregion
}

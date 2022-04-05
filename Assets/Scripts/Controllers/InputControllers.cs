using System;
using UnityEngine;

public class InputControllers : MonoBehaviour
{


    //This a comment // comments dont get read from the compiler
    //This allows programmers to put english comments in their to code to explain their code in english not in C# code

    //Public - Other Scripts can access theses variables 
    [Range(0.01f, 0.99f)] //This limits you in the editor so you can't go beyond the ranges of .01 and .99
    public float AxisXDeadzone = 0.5f, AxisYDeadzone = 0.5f; // Float - this is a variables data type that contains numbers with decimal points in them, we can assign float values to a float variable using f at the end of the number


    // /**/ Comment block it turns everything into comment between /* and */
    /*Events and Delegate (action is is generic simplied version of Events and Delegates) - this a way to tell another script when this happens in this script you need to do your action
    //This is so I can remove anything that is NOT a part of your movement game feel code
    //I am doing this so you don't have to worry about input code it self, I want you think about the logic of the movement it self
    //DO NOT WORRY ABOUT THIS FOR NOW */
    public Action Jump = delegate { };
    public Action<float> AxisX = delegate { };
    public Action<float> AxisY = delegate { };
    //DO NOT WORRY ABOUT THIS FOR NOW

    //private - only this script can access theses variables 
    private bool allowInput; // bool - this is a variables data type it can only have two values true or false
    private float AxisXDeadzoneLeft, AxisYDeadzoneDown; //check the deadzone Opposite range 
    private const string horizontal = "Horizontal", vertical = "Vertical", jump = "Jump";// String  - this is a variables data type that contains series of characters, 
    //DO NOT WORRY ABOUT THE CONST WORD


    //This function is called at the start of the game;
    void Start()
    {
        // = is an assignment operator, we are assigning the value on the right to the variable on the left
        allowInput = true;
        AxisXDeadzoneLeft = 0 - AxisXDeadzone;
        AxisYDeadzoneDown = 0 - AxisYDeadzone;
    }

    // Update is called once per frame
    void Update()
    {

        // Do we progress input ? the input only happens if the expression is true  
        // == is a comparison operator, equal to
        if (allowInput == true)
        {

            // > is a comparison operator, Greater than , < is a comparison operator, Less than
            if (Input.GetAxis(horizontal) > AxisXDeadzone || Input.GetAxis(horizontal) < AxisXDeadzoneLeft)
            {
                AxisX?.Invoke(Input.GetAxis("Horizontal"));
            }
            if (Input.GetAxis(vertical) > AxisYDeadzone || Input.GetAxis(vertical) < AxisYDeadzoneDown)
            {
                AxisY?.Invoke(Input.GetAxis("Vertical"));
            }
            if (Input.GetButtonDown(jump))
            {
                Jump?.Invoke();
            }
           
        }
    }
}

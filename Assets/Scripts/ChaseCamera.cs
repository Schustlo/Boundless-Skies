using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    public GameObject PlayerBall;
    public Vector3 offset;
    #region UNITY API FUNCTIONS

    void Awake()
    {
        if (PlayerBall == null)
        {

            Debug.LogError("Hello Unity Student, this is Professor Tongue! I am giving you this error because, the PlayerBall is empty in the inspector" +
                " HINT: if you assign the PlayerBall in the inspector I will go away ");
            return;
        }
        if (PlayerBall.GetComponent<BallMovement>() == null)
        {
            Debug.LogError("Hello Unity Student, this is Professor Tongue! I am giving you this error because, the gameobject you assigned isn't the gameobject with movement script attached" +
                " HINT: if you assign the PlayerBall gameobject with the movement script attached in the inspector I will go away ");
        }
        else
        {
            offset = transform.position + PlayerBall.transform.position;
        }
       
    }

    void LateUpdate()
    {
        transform.position = PlayerBall.transform.position + offset;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameend : MonoBehaviour
{
    public player p;


    void OnTriggernEnter(Collider other)
    {
        Debug.Log("collision");
        if (p.coins >= 5)
        {
            SceneManager.LoadScene("start");
        }
        
    }
}

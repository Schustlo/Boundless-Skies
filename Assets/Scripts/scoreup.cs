using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreup : MonoBehaviour
{
    public player p;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            p.coins++;
            Destroy(this.gameObject, .1f);
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour
{
    public GameObject plat;
    public GameObject start;
    public GameObject end;
     bool  stend = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        stend = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stend == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, speed);
        }

        if (stend == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, start.transform.position, speed);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("switch")&& stend == false)
        {
            stend = true;
        }

        if (col.gameObject.CompareTag("switch") && stend == true)
        {
            stend = false;
        }
    }
}

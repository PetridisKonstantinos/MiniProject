using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public bool ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ship)
        {
            transform.LookAt(transform.position + -GetComponent<Rigidbody>().velocity);
        }
    }
}

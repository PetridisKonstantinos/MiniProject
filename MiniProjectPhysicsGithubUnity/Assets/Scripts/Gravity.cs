using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    GameObject[] objects;//Array of all other object in the scene

    float G = 6.673e-8f;//Graviation constant reduced due to scale
    float scaleMultiplier = 5000;//Used to increase attraction due to scale(same in all scripts)
    public bool showRays;

    Vector3 gravity;//Variable to accumulate gravity of all objects

    // Start is called before the first frame update
    void Start()
    {
        objects=GameObject.FindGameObjectsWithTag("Object");
        gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        gravity = Vector3.zero;
        foreach(GameObject go in objects)
        {
            if (go != this.gameObject)
            {
                Vector3 u = this.transform.position - go.transform.position;
                float r = u.magnitude;
                u.Normalize();
                u = u * scaleMultiplier;

                Vector3 grav = (G * (go.GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass / (r * r))) * -u;
                if(showRays)Debug.DrawRay(transform.position + grav.normalized * transform.localScale.magnitude*0.3f, grav * 5, Color.green);

                gravity += grav;
            }
        }
        GetComponent<Rigidbody>().AddForce(gravity*Time.deltaTime, ForceMode.Impulse); 
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradIncForce : MonoBehaviour
{
    public GameObject basePlanet;//Variable that represents the planet the object is onto.

    // Start is called before the first frame update
    void Start()
    {
        //First we need to import the orbiting velocity, and all forces that will be applied to the object will need to end up with this velocity.
        //Then, we should calculate the force to be applied so as the object will lift off and travel beyond the atmosphere.
        //After that, the velocity's direction and magnitude needs to be altered in order to match the orbit's velocity and escape gravity.
       
    }

    // Update is called once per frame
    void Update()
    {
        // Direction of the vector that will be used to apply the force.
        Vector3 r = (transform.position - basePlanet.transform.position).normalized;
        //GetComponent<Rigidbody>().AddForce(r * Time.deltaTime * additForce, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialOrbitVelocity : MonoBehaviour
{
    public GameObject obOrbiting;
    float G = 6.673e-8f;//Graviation constant reduced due to scale
    float scaleMultiplier = 5000;//Used to increase attraction due to scale(same in all scripts)
    // Start is called before the first frame update
    void Start()
    {
        Vector3 r = transform.position - obOrbiting.transform.position;
        
        Vector3 velocity = Mathf.Sqrt(((G * obOrbiting.GetComponent<Rigidbody>().mass) / r.magnitude)*scaleMultiplier)*(Vector3.Cross(r.normalized,Vector3.up));

        GetComponent<Rigidbody>().velocity=velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

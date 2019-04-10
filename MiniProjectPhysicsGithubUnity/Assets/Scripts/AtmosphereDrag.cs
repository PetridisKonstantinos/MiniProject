using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereDrag : MonoBehaviour
{
    GameObject[] objects;
    public float dragCoefficient;
    float scaleMultiplier = 5000;//Used to increase attraction due to scale(same in all scripts)

    // Start is called before the first frame update
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Object");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in objects)
        {
            Vector3 u = this.transform.position - go.transform.position;
            if (u.magnitude > go.GetComponent<Renderer>().bounds.extents.x && u.magnitude <= go.transform.GetChild(0).GetComponent<Renderer>().bounds.extents.x+1)
            {
                float interpolationVal = (u.magnitude - go.GetComponent<Renderer>().bounds.extents.x) / (go.transform.GetChild(0).GetComponent<Renderer>().bounds.extents.x - go.GetComponent<Renderer>().bounds.extents.x);
                float density = Mathf.Lerp(go.transform.GetChild(0).GetComponent<atmosphereInfo>().maxDensity, go.transform.GetChild(0).GetComponent<atmosphereInfo>().minDensity, interpolationVal);
                float refArea = (Mathf.PI * Mathf.Pow(GetComponent<Renderer>().bounds.extents.magnitude, 2.0f));
                Vector3 dragForce = -0.5f * density * Mathf.Pow(GetComponent<Rigidbody>().velocity.magnitude, 2) * dragCoefficient * refArea * GetComponent<Rigidbody>().velocity.normalized;

                GetComponent<Rigidbody>().AddForce(dragForce * Time.deltaTime, ForceMode.Impulse);
                Debug.DrawRay(transform.position + dragForce.normalized * transform.localScale.magnitude * 0.3f, dragForce*0.2f, Color.red);
                //print(dragForce);
            }
        }
    }
}

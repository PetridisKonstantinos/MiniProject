using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIchangeSimulationSpeed : MonoBehaviour
{
   public void changed()
    {
        Time.timeScale= GetComponent<Slider>().value;
        GetComponentInChildren<Text>().text = "Simulation Time Scale: " + Mathf.Round(Time.timeScale);
    }
}

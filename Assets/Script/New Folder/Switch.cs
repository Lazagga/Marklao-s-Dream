using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public List<GameObject> Lights;
    public Material Light_material;
    public int state = 0;       //²¨Áü
    public void Interact()
    {
        if(state == 0)
        {
            foreach(GameObject light in Lights)
            {
                light.GetComponent<Light>().enabled = true;
                light.GetComponent<Renderer>().material.color = Light_material.color;
            }
        }
        else
        {
            foreach (GameObject light in Lights)
            {
                light.GetComponent<Light>().enabled = false;
                light.GetComponent<Renderer>().material.color = Color.black;
            }
        }
        state = 1 - state;
    }

    public void Start()
    {
        Light_material = Lights[0].GetComponent<Renderer>().material;
        __init__();
    }

    public void __init__()
    {
        state = 0;
        foreach (GameObject light in Lights)
        {
            light.GetComponent<Light>().enabled = false;
            light.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}

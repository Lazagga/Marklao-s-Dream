using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public List<GameObject> Lights;
    private Material lightOnMaterial;
    private bool isOn;

    private Light[] lightComponents;
    private Renderer[] rendererComponents;

    private void Start()
    {
        lightComponents = new Light[Lights.Count];
        rendererComponents = new Renderer[Lights.Count];
        for (int i = 0; i < Lights.Count; i++)
        {
            lightComponents[i] = Lights[i].GetComponent<Light>();
            rendererComponents[i] = Lights[i].GetComponent<Renderer>();
        }
        lightOnMaterial = rendererComponents[0].material;
        Init();
    }

    public void Init()
    {
        isOn = false;
        for (int i = 0; i < Lights.Count; i++)
        {
            lightComponents[i].enabled = false;
            rendererComponents[i].material.color = Color.black;
        }
    }

    public void Interact()
    {
        isOn = !isOn;
        for (int i = 0; i < Lights.Count; i++)
        {
            lightComponents[i].enabled = isOn;
            rendererComponents[i].material.color = isOn ? lightOnMaterial.color : Color.black;
        }
    }
}

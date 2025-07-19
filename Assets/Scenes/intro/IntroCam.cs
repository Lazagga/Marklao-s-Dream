using UnityEngine;

public class IntroCam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = GameObject.FindWithTag("Player").transform.position;
        this.gameObject.transform.rotation = GameObject.FindWithTag("Player").transform.rotation;
    }
}

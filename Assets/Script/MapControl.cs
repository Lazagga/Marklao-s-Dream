using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public Dictionary<string, string> success = new Dictionary<string, string>();

    private int SignCount;
    private bool successAble;
    private string rightDoor;
    public GameObject Sign;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string randomKey()
    {
        List<string> keys = new List<string>(success.Keys);
        int randIndex = Random.Range(0, keys.Count);
        string randKey = keys[randIndex];
        return randKey;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(successAble)
        {
            if(collision.gameObject.tag == rightDoor)
            {

            }
            else
            {

            }
        }
        else
        {

        }
    }
}

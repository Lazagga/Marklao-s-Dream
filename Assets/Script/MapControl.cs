using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public GameObject Map;
    public GameObject[] prefabMap;

    private List<int> events = new List<int>();
    private Transform next;

    private int mapCount;
    private int mapNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapCount = 8;
        Map = Instantiate(prefabMap[0], Vector3.zero, Quaternion.identity);
        events.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "correct")
        {
            next = collision.gameObject.transform;
            //ø§∏Æ∫£¿Ã≈Õ ¿Ãµøæ¿
            Destroy(Map);
            mapNum = Random.Range(1, mapCount);
            while(events.Contains(mapNum))
            {
                mapNum = Random.Range(1, mapCount);
            }
            Map = Instantiate(prefabMap[mapNum], next);
            events.Add(mapNum);
            mapCount--;
        }

    }
}

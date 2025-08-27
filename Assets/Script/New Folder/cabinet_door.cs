using System.Collections;
using UnityEngine;

public class cabinet_door : MonoBehaviour, IInteractable
{
    public GameObject door;
    public int door_state = 0;

    public void Start()
    {
        door = this.gameObject;
        __init__();
    }

    public void __init__()
    {
        door.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    public void Interact()
    {
        if(door_state == 0)      //문이 닫혀있는 경우
        {
            StartCoroutine(door_open());
        }
        else if (door_state == 1)
        {
            StartCoroutine(door_close());
        }

    }

    public IEnumerator door_open()
    {
        door_state = 2;


        Quaternion startRot = transform.localRotation;
        Quaternion endRot = transform.localRotation * Quaternion.Euler(0f, 0f, -90f);

        float t = 0f;
        float duration = 1f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            door.transform.localRotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        door.transform.localRotation = endRot;


        door_state = 1;
    }


    public IEnumerator door_close()
    {
        door_state = 2;


        Quaternion startRot = transform.localRotation;
        Quaternion endRot = transform.localRotation * Quaternion.Euler(0f, 0f, 90f);

        float t = 0f;
        float duration = 1f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            door.transform.localRotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        door.transform.localRotation = endRot;


        door_state = 0;
    }



}

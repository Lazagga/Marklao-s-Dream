using System.Collections;
using UnityEngine;

public class storage_door : MonoBehaviour, IInteractable
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
        ;
    }

    public void Interact()
    {
        if (door_state == 0)      //문이 닫혀있는 경우
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

        Vector3 startPos = this.transform.localPosition;  // 초기 상태
        Vector3 endPos = this.transform.localPosition + new Vector3(-0.45f, 0.0f, 0.0f);      // 열렸을 때

        float t = 0f;
        float duration = 1f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            door.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        door.transform.localPosition = endPos;

        door_state = 1;
    }

    public IEnumerator door_close()
    {
        door_state = 2;

        Vector3 startPos = this.transform.localPosition;  // 초기 상태
        Vector3 endPos = this.transform.localPosition - new Vector3(-0.45f, 0.0f, 0.0f);      // 열렸을 때

        float t = 0f;
        float duration = 1f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            door.transform.localPosition = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        door.transform.localPosition = endPos;

        door_state = 0;
    }
}

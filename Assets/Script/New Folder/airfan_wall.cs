using System.Collections;
using UnityEngine;

public class airfan_wall : MonoBehaviour, IInteractable
{
    public GameObject wing;
    public int state = 0;           //0정지 : 1작동

    public void Start()
    {
        __init__();
    }

    public void __init__()
    {
        state = 0;
    }

    public void Interact()
    {
        if(state == 0)
        {
            state = 1;
            StartCoroutine(rotate());
        }
        else
        {
            state = 0;
        }

    }



    public IEnumerator rotate()
    {
        while(true)
        {
            wing.transform.Rotate(30, 0, 0);
            yield return new WaitForSeconds(0.1f);
            if (state == 0) yield break;
        }
    }
}

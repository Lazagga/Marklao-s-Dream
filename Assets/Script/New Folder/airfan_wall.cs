using System.Collections;
using UnityEngine;

public class airfan_wall : MonoBehaviour, IInteractable
{
    public GameObject wing;
    private bool isOn = false;  // false = 꺼짐, true = 켜짐

    private void Start()
    {
        isOn = false;
    }

    public void Interact()
    {
        isOn = !isOn;
        if (isOn) StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (isOn)
        {
            wing.transform.Rotate(30, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

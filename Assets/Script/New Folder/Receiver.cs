using System.Collections;
using TMPro;
using UnityEngine;

public class Receiver : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI KeyBoard;
    public string text;

    public void Start()
    {
        __init__();
    }

    public void Interact()
    {
        StartCoroutine(keyPad());
        KeyBoard.text = text;
    }

    IEnumerator keyPad()
    {
        yield return new WaitUntil(() =>
        {
            if (Input.anyKeyDown)
            {
                foreach (char c in Input.inputString)
                {
                    text += c.ToString();
                    return true;
                }
            }
            return false;
        }
        );
    }


    public void __init__()
    {
        text = string.Empty;
        KeyBoard.text = text;
    }
}

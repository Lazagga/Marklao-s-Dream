using UnityEngine;
using TMPro;

public class SignBoard : MonoBehaviour
{
    public TMP_Text SignText;

    private void Awake()
    {
        
    }

    public void UpdateSign(string message)
    {
        SignText.text = message;
    }
}

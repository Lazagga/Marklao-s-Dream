using UnityEngine;
using TMPro;

public class SignBoard : MonoBehaviour
{
    public TMP_Text SignText;

    private void Awake()
    {
        if (SignText == null)
            SignText = GetComponentInChildren<TextMeshPro>();
    }

    public void UpdateSign(string message)
    {
        SignText.text = message;
    }
}

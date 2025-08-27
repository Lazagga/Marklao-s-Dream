using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class wood_frame : MonoBehaviour, IInteractable
{
    public int state = 0;

    public void Interact()
    {
        state++;
        this.transform.Rotate(45.0f, 0.0f, 0.0f);
        if (state == 8) { state = 0; }
    }
}

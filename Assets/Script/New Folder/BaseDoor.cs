using System.Collections;
using UnityEngine;

public abstract class BaseDoor : MonoBehaviour, IInteractable
{
    protected enum DoorState { Closed = 0, Open = 1, Animating = 2 }

    protected DoorState doorState = DoorState.Closed;
    protected const float AnimDuration = 1f;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init() { }

    public void Interact()
    {
        if (doorState == DoorState.Closed)
            StartCoroutine(OpenCoroutine());
        else if (doorState == DoorState.Open)
            StartCoroutine(CloseCoroutine());
    }

    protected abstract IEnumerator OpenCoroutine();
    protected abstract IEnumerator CloseCoroutine();
}

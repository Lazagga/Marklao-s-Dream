using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public enum DoorDirection { Front, Back, Left, Right }
    public DoorDirection direction;

    public GameObject doorBody;
    public float animTime = 3f;

    public bool isLock = false;

    public void __init__()
    {
        isLock = false;
    }

    public void Interact()
    {
        if (!isLock)
        {
            if (direction == DoorDirection.Front)
                GameManager.Instance.CompleteCommand(CommandType.EnterFrontDoor);
            if (direction == DoorDirection.Back)
                GameManager.Instance.CompleteCommand(CommandType.EnterBackDoor);
            if (direction == DoorDirection.Left)
                GameManager.Instance.CompleteCommand(CommandType.EnterLeftDoor);
            if (direction == DoorDirection.Right)
                GameManager.Instance.CompleteCommand(CommandType.EnterRightDoor);

            doorBody.transform.Rotate(0, 90, 0);

            GameManager.Instance.LockOtherDoors(this);
        }
    }

    public void LockDoor()
    {
        isLock = true;
    }
}

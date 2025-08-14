using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public enum DoorDirection { Front, Back, Left, Right }
    public DoorDirection direction;

    public GameObject doorBody;

    public void Interact()
    {
        if (GameManager.Instance.currentStep == GameManager.Step.Room)
        {
            if (direction == DoorDirection.Front)
                GameManager.Instance.CompleteCommand(CommandType.EnterFrontDoor);
            if (direction == DoorDirection.Back)
                GameManager.Instance.CompleteCommand(CommandType.EnterBackDoor);
            if (direction == DoorDirection.Left)
                GameManager.Instance.CompleteCommand(CommandType.EnterLeftDoor);
            if (direction == DoorDirection.Right)
                GameManager.Instance.CompleteCommand(CommandType.EnterRightDoor);

            GameManager.Instance.OpenDoor(this);

            GameManager.Instance.currentStep = GameManager.Step.Corridor;
        }

        if (GameManager.Instance.currentStep == GameManager.Step.Teleport)
        {
            GameManager.Instance.OpenDoor(this);
            GameManager.Instance.currentStep = GameManager.Step.Room;
        }
    }
}

using UnityEngine;

public class Copier : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (PlayerInventory.Instance.numberDocument > 0)
        {
            PlayerInventory.Instance.ChangeNumberDocument(1);
            GameManager.Instance.CompleteCommand(CommandType.CopyDocument);
        }
    }
}
using UnityEngine;

public class Copier : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        PlayerInventory.Instance.ChangeNumberDocument(1);
        GameManager.Instance.CompleteCommand(CommandType.CopyDocument);
    }
}
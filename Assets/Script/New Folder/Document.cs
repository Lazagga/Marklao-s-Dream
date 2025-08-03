using UnityEngine;

public class Document : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        PlayerInventory.Instance.ChangeNumberDocument(1);
        gameObject.SetActive(false);
    }
}

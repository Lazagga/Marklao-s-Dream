using UnityEngine;

public class Desk : MonoBehaviour, IInteractable
{
    public bool HasDocument { get; private set; }
    private Document myDoc;

    private void Awake()
    {
        myDoc = GetComponentInChildren<Document>(true);
        if (myDoc == null) Debug.LogError($"Desk '{name}': Document not found in children.");
        __init__();
    }

    public void __init__()
    {
        if (myDoc == null) return;
        myDoc.gameObject.SetActive(false);
        HasDocument = false;
    }

    public void Interact()
    {
        if (myDoc == null) return;

        if (PlayerInventory.Instance.numberDocument > 0 && !HasDocument)
        {
            myDoc.gameObject.SetActive(true);
            HasDocument = true;
            PlayerInventory.Instance.ChangeNumberDocument(-1);
            GameManager.Instance.CheckAllDesks();
        }
        else if (HasDocument)
        {
            myDoc.gameObject.SetActive(false);
            HasDocument = false;
            PlayerInventory.Instance.ChangeNumberDocument(1);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour, IInteractable
{
    public bool HasDocument { get; private set; }
    private Document myDoc;

    public void Start()
    {
        myDoc = GetComponentInChildren<Document>();
        __init__();
    }

    public void __init__()
    {
        myDoc.gameObject.SetActive(false);
        HasDocument = false;
    }
    public void Interact()
    {
        if (PlayerInventory.Instance.numberDocument > 0 && !HasDocument)
        {
            myDoc.gameObject.SetActive(true);
            HasDocument = true;
            PlayerInventory.Instance.ChangeNumberDocument(-1);
        }
        else if (HasDocument)
        {
            myDoc.gameObject.SetActive(false);
            HasDocument = false;
            PlayerInventory.Instance.ChangeNumberDocument(1);
        }
    }
}

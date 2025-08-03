using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour, IInteractable
{
    public bool HasDocument { get; private set; }
    private GameObject myDoc;

    public void Start()
    {
        myDoc = GetComponentInChildren<Document>().gameObject;
        __init__();
    }

    public void __init__()
    {
        myDoc.SetActive(false);
        HasDocument = false;
    }
    public void Interact()
    {
        if (PlayerInventory.Instance.numberDocument > 0 && !HasDocument)
        {
            myDoc.SetActive(true);
            HasDocument = true;
            PlayerInventory.Instance.ChangeNumberDocument(-1);
        }
        else if (HasDocument)
        {
            myDoc.SetActive(false);
            HasDocument = false;
            PlayerInventory.Instance.ChangeNumberDocument(1);
        }
    }
}

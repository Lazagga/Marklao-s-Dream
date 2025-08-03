using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    public GameObject heldDocument;
    public int numberDocument;
    public int PlayerHp = 3;

    private void Awake()
    {
        heldDocument.SetActive(false);
        Instance = this;
        numberDocument = 0;
        PlayerHp = 3;
    }

    public void ChangeNumberDocument(int val)
    {
        numberDocument += val;
        if (numberDocument == 0) heldDocument.gameObject.SetActive(false);
        else heldDocument.gameObject.SetActive(true);
    }
}

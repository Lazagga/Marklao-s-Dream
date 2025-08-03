using UnityEngine;

public class Shredder : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (PlayerInventory.Instance.numberDocument > 0)
        {
            PlayerInventory.Instance.ChangeNumberDocument(-1);
            GameManager.Instance.CompleteCommand(CommandType.ShredDocument);
        }

        else
        {
            PlayerInventory.Instance.PlayerHp--;
            if(PlayerInventory.Instance.PlayerHp == 0)
                GameManager.Instance.CompleteCommand(CommandType.DieInShredder);
        }
    }
}
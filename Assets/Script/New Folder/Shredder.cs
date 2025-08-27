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

        else if(PlayerInventory.Instance.heldingObj == 0)
        {
            PlayerInventory.Instance.PlayerHp--;
            if(PlayerInventory.Instance.PlayerHp == 0)
                GameManager.Instance.CompleteCommand(CommandType.DieInShredder);
        }
        else if(PlayerInventory.Instance.heldingObj == (int)PlayerInventory.obj_name.doll)
        {
            //doll kill
            PlayerInventory.Instance.interact_obj(PlayerInventory.Instance.heldingObj);
        }
    }
}
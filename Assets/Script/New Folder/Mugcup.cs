using UnityEngine;

public class Mugcup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int id = (int)PlayerInventory.obj_name.mugcup;

        if (this.gameObject.activeSelf)     //형태가 있는 경우 -> 주기
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(false);
        }
        else                                  //형태가 없는 경우(상위 오브젝트에서 발생) -> 받기
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(true);
        }
        
    }
}

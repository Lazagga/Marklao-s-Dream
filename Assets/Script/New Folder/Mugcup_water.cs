using UnityEngine;

public class Mugcup_water : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int id = (int)PlayerInventory.obj_name.mugcup_water;
        if (this.gameObject.activeSelf)     //형태가 있는 경우 -> 주기
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(false);
        }
        else                                  //형태가 없는 경우(상위 오브젝트에 의해 발생) -> 받기
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(true);
        }
    }
}

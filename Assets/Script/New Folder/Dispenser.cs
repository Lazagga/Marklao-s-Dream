using UnityEngine;

public class Dispenser : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int mugcup = (int)PlayerInventory.obj_name.mugcup;
        int mugcup_water = (int)PlayerInventory.obj_name.mugcup_water;

        if (PlayerInventory.Instance.heldingObj == 0)        //아무것도 안들고 있는 경우 무시
        {

        }
        else if(PlayerInventory.Instance.heldingObj == mugcup)       //머그컵을 들고 있는 경우
        {
            PlayerInventory.Instance.interact_obj(mugcup);          //mugcup해제
            PlayerInventory.Instance.interact_obj(mugcup_water);    //mugcup_water착용

        }
        else if (PlayerInventory.Instance.heldingObj == mugcup_water)       //물이든 머그컵을 들고 있는 경우
        {
            PlayerInventory.Instance.interact_obj(mugcup_water);    //mugcup_water해제
            PlayerInventory.Instance.interact_obj(mugcup);          //mugcup착용
        }
    }
}

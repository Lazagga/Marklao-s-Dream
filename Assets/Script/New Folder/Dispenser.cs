using UnityEngine;

public class Dispenser : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int mugcup = (int)PlayerInventory.obj_name.mugcup;
        int mugcup_water = (int)PlayerInventory.obj_name.mugcup_water;

        if (PlayerInventory.Instance.heldingObj == 0)        //�ƹ��͵� �ȵ�� �ִ� ��� ����
        {

        }
        else if(PlayerInventory.Instance.heldingObj == mugcup)       //�ӱ����� ��� �ִ� ���
        {
            PlayerInventory.Instance.interact_obj(mugcup);          //mugcup����
            PlayerInventory.Instance.interact_obj(mugcup_water);    //mugcup_water����

        }
        else if (PlayerInventory.Instance.heldingObj == mugcup_water)       //���̵� �ӱ����� ��� �ִ� ���
        {
            PlayerInventory.Instance.interact_obj(mugcup_water);    //mugcup_water����
            PlayerInventory.Instance.interact_obj(mugcup);          //mugcup����
        }
    }
}

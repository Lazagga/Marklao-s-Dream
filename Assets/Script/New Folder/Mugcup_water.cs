using UnityEngine;

public class Mugcup_water : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int id = (int)PlayerInventory.obj_name.mugcup_water;
        if (this.gameObject.activeSelf)     //���°� �ִ� ��� -> �ֱ�
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(false);
        }
        else                                  //���°� ���� ���(���� ������Ʈ�� ���� �߻�) -> �ޱ�
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(true);
        }
    }
}

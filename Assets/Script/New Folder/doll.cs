using UnityEngine;

public class doll : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int id = (int)PlayerInventory.obj_name.doll;

        if (this.gameObject.activeSelf)     //���°� �ִ� ��� -> �ֱ�
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(false);
        }
        else                                  //���°� ���� ���(���� ������Ʈ���� �߻�) -> �ޱ�
        {
            PlayerInventory.Instance.interact_obj(id);
            gameObject.SetActive(true);
        }
    }
}

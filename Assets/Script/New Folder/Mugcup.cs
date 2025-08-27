using UnityEngine;

public class Mugcup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int id = (int)PlayerInventory.obj_name.mugcup;

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

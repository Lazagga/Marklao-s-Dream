using NUnit.Framework.Constraints;
using UnityEngine;

public enum State
{
    none = 0,
    mugcup = (int)PlayerInventory.obj_name.mugcup,
    mugcup_water = (int)PlayerInventory.obj_name.mugcup_water
}
public class Mugcup_coaster : MonoBehaviour, IInteractable
{
    public State HasMug;        //���� �� Ȧ���� ����
    
    public GameObject MugcupObj;
    public Mugcup MugcupCode;

    public GameObject Mugcup_waterObj;
    public Mugcup_water Mugcup_waterCode;

    public void Start()                 //���� ������Ʈ�� �ڵ带 ���
    {
        MugcupCode = MugcupObj.GetComponent<Mugcup>();
        Mugcup_waterCode = Mugcup_waterObj.GetComponent<Mugcup_water>();
        __init__();
    }

    public void Interact()          
    {
        int id_mug = (int)PlayerInventory.obj_name.mugcup;
        int id_mug_water = (int)PlayerInventory.obj_name.mugcup_water;


        switch (HasMug)
        {
            case State.none: {        //Ȧ�� ���� �ƹ��͵� ���� ���
                    if(PlayerInventory.Instance.heldingObj == id_mug)                   //mugcup�� ��� ������
                    {
                        HasMug = State.mugcup;
                        MugcupCode.Interact();
                    }
                    else if (PlayerInventory.Instance.heldingObj == id_mug_water)       //mugcup_water�� ��� ������
                    {
                        HasMug = State.mugcup_water;
                        Mugcup_waterCode.Interact();
                    }
                    break;
                }
            default:{        //Ȧ�� ���� ���� �ִ� ���
                    if (PlayerInventory.Instance.heldingObj == 0)          //�տ� ��� �ִ� ���� ������
                    {
                        if((int)HasMug == id_mug) {
                            HasMug = 0;
                            MugcupCode.Interact();
                        }
                        else if((int)HasMug == id_mug_water) {
                            HasMug = 0;
                            Mugcup_waterCode.Interact();
                        }
                    }
                    break;
                }

        }

    }

    public void __init__()              //hasMug�� �°� ������Ʈ ����
    {
        switch (HasMug)
        {
            case State.none:{
                    MugcupObj.SetActive(false);
                    Mugcup_waterObj.SetActive(false);
                    break;
            }
            case State.mugcup:
                {
                    MugcupObj.SetActive(true);
                    Mugcup_waterObj.SetActive(false);
                    break;
                }
            case State.mugcup_water:
                {
                    MugcupObj.SetActive(false);
                    Mugcup_waterObj.SetActive(true);
                    break;
                }
        }
        
    }

}

using JetBrains.Annotations;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    public GameObject heldDocument;
    public int numberDocument;


    public enum obj_name{       //�� �� �ִ� ������Ʈ ����
        mugcup = 1, 
        mugcup_water = 2,
        doll = 3
    }
    public GameObject[] obj;
    public int heldingObj = 0;         //��� �ִ� ������Ʈ 0�̸� �� ��� ����

    public int PlayerHp = 3;


    private void Awake()
    {
        __init__();

        Instance = this;
        numberDocument = 0;
        PlayerHp = 3;
    }

    public void __init__()
    {
        heldDocument.SetActive(false);
        obj[(int)obj_name.mugcup].SetActive(false);
        obj[(int)obj_name.mugcup_water].SetActive(false);
        obj[(int)obj_name.doll].SetActive(false);
    }

    public void ChangeNumberDocument(int val)
    {
        numberDocument += val;
        if (numberDocument == 0) heldDocument.gameObject.SetActive(false);
        else heldDocument.gameObject.SetActive(true);
    }


    public void interact_obj(int val)               //������Ʈ(��� ��ü) ��ȣ�ۿ�
    {
        if(heldingObj == 0){                           //�Ǽ��� ���
            heldingObj = val;
            obj[val].gameObject.SetActive(true);
        }
        else if(heldingObj == val)                     //������ ��� �ִ� ���ǰ� ������ ���
        {
            heldingObj = 0;
            obj[val].gameObject.SetActive(false);
        }
        else                                        //�ٸ� ������ ��� ���� ���
        {
            Debug.Log("�� �� ���� ����");
        }
    }

}

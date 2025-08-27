using JetBrains.Annotations;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    public GameObject heldDocument;
    public int numberDocument;


    public enum obj_name{       //들 수 있는 오브젝트 종류
        mugcup = 1, 
        mugcup_water = 2,
        doll = 3
    }
    public GameObject[] obj;
    public int heldingObj = 0;         //들고 있는 오브젝트 0이면 안 들고 있음

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


    public void interact_obj(int val)               //오브젝트(드는 물체) 상호작용
    {
        if(heldingObj == 0){                           //맨손인 경우
            heldingObj = val;
            obj[val].gameObject.SetActive(true);
        }
        else if(heldingObj == val)                     //기존에 들고 있던 물건과 동일한 경우
        {
            heldingObj = 0;
            obj[val].gameObject.SetActive(false);
        }
        else                                        //다른 물건을 들고 있을 경우
        {
            Debug.Log("더 들 수가 없다");
        }
    }

}

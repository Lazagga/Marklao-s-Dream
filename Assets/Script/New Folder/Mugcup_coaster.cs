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
    public State HasMug;        //현재 컵 홀더의 상태
    
    public GameObject MugcupObj;
    public Mugcup MugcupCode;

    public GameObject Mugcup_waterObj;
    public Mugcup_water Mugcup_waterCode;

    public void Start()                 //하위 오브젝트의 코드를 기록
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
            case State.none: {        //홀더 위에 아무것도 없는 경우
                    if(PlayerInventory.Instance.heldingObj == id_mug)                   //mugcup을 들고 있으면
                    {
                        HasMug = State.mugcup;
                        MugcupCode.Interact();
                    }
                    else if (PlayerInventory.Instance.heldingObj == id_mug_water)       //mugcup_water을 들고 있으면
                    {
                        HasMug = State.mugcup_water;
                        Mugcup_waterCode.Interact();
                    }
                    break;
                }
            default:{        //홀더 위에 뭔가 있는 경우
                    if (PlayerInventory.Instance.heldingObj == 0)          //손에 들고 있는 것이 없으면
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

    public void __init__()              //hasMug에 맞게 오브젝트 설정
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

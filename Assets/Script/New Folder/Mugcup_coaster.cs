using UnityEngine;

public class Mugcup_coaster : MonoBehaviour, IInteractable
{
    public enum MugState
    {
        None = 0,
        Mugcup = (int)PlayerInventory.obj_name.mugcup,
        MugcupWater = (int)PlayerInventory.obj_name.mugcup_water
    }

    public MugState HasMug;

    public GameObject MugcupObj;
    public Mugcup MugcupCode;

    public GameObject Mugcup_waterObj;
    public Mugcup_water Mugcup_waterCode;

    private void Start()
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
            case MugState.None:
                if (PlayerInventory.Instance.heldingObj == id_mug)
                {
                    HasMug = MugState.Mugcup;
                    MugcupCode.Interact();
                }
                else if (PlayerInventory.Instance.heldingObj == id_mug_water)
                {
                    HasMug = MugState.MugcupWater;
                    Mugcup_waterCode.Interact();
                }
                break;

            default:
                if (PlayerInventory.Instance.heldingObj == 0)
                {
                    if ((int)HasMug == id_mug)
                    {
                        HasMug = MugState.None;
                        MugcupCode.Interact();
                    }
                    else if ((int)HasMug == id_mug_water)
                    {
                        HasMug = MugState.None;
                        Mugcup_waterCode.Interact();
                    }
                }
                break;
        }
    }

    public void __init__()
    {
        switch (HasMug)
        {
            case MugState.None:
                MugcupObj.SetActive(false);
                Mugcup_waterObj.SetActive(false);
                break;
            case MugState.Mugcup:
                MugcupObj.SetActive(true);
                Mugcup_waterObj.SetActive(false);
                break;
            case MugState.MugcupWater:
                MugcupObj.SetActive(false);
                Mugcup_waterObj.SetActive(true);
                break;
        }
    }
}

using UnityEngine;

public class Flowerpot : MonoBehaviour, IInteractable
{
    public GameObject normal_state;
    public GameObject break_state;

    public void Awake()
    {
        __init__();
    }

    public void __init__()
    {
        normal_state.gameObject.SetActive(true);
        break_state.gameObject.SetActive(false);
    }
    public void Interact()
    {
        normal_state.gameObject.SetActive(false);
        break_state.gameObject.SetActive(true);
    }
    
}

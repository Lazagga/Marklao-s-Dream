using UnityEngine;

public class Clock : MonoBehaviour
{
    public int state;
    public GameObject niddle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameManager.Instance.stageLevel;
        __init__();
    }

    public void __init__()
    {
        niddle.transform.localRotation = Quaternion.Euler(-120.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        state = GameManager.Instance.stageLevel;
        niddle.transform.localRotation = Quaternion.Euler(-90.0f - 30.0f*state, 0.0f, 0.0f);
    }
}

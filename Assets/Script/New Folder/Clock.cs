using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject needle;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        needle.transform.localRotation = Quaternion.Euler(-120f, 0f, 0f);
    }

    private void Update()
    {
        if (GameManager.Instance == null) return;
        float angle = -90f - 30f * GameManager.Instance.stageLevel;
        needle.transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}

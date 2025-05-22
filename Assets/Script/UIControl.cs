using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    private bool isPhoneUp;
    private bool isLightOn;

    private Vector2 DownPos = new Vector2(100, -400);
    private Vector2 UpPos = new Vector2(100, 0);

    public Image Phone;
    public GameObject[] PhoneUI;
    public GameObject PhoneLight;

    public float animTime = 1f;

    public enum state
    {
        Idle,
        Call,
        Guide,
        Setting
    }

    public state CurrentState;

    public void CurrnetCanvas()
    {
        foreach (GameObject canvas in PhoneUI) { canvas.SetActive(false); }
        switch (CurrentState)
        {
            case state.Idle:
                break;
            case state.Call:
                PhoneUI[0].SetActive(true);
                break;
            case state.Guide:
                PhoneUI[1].SetActive(true);
                break;
            case state.Setting:
                PhoneUI[2].SetActive(true);
                break;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPhoneUp = false;
        isLightOn = false;

        CurrentState = state.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPhoneUp = isPhoneUp ? false : true;
            if (isPhoneUp)
            {
                StopCoroutine("PhoneDown");
                StartCoroutine("PhoneUp");
            }
            else
            {
                StopCoroutine("PhoneUp");
                StartCoroutine("PhoneDown");
            }
        }

        if(isPhoneUp)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            CurrentState = state.Idle;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        CurrnetCanvas();
    }

    IEnumerator PhoneUp()
    {
        WaitForSeconds wtf = new WaitForSeconds(Time.deltaTime / 2);
        float pastTime = 0f;
        while (pastTime < animTime)
        {
            Phone.rectTransform.anchoredPosition = Vector2.Lerp(Phone.rectTransform.anchoredPosition, UpPos, pastTime / animTime);
            pastTime += Time.deltaTime / 2;
            yield return wtf;
        }
        Phone.rectTransform.anchoredPosition = UpPos;
    }

    IEnumerator PhoneDown()
    {
        WaitForSeconds wtf = new WaitForSeconds(Time.deltaTime / 2);
        float pastTime = 0f;
        while (pastTime < animTime)
        {
            Phone.rectTransform.anchoredPosition = Vector2.Lerp(Phone.rectTransform.anchoredPosition, DownPos, pastTime / animTime);
            pastTime += Time.deltaTime / 2;
            yield return wtf;
        }
        Phone.rectTransform.anchoredPosition = DownPos;
    }

    public void OnCall()
    {
        CurrentState = state.Call;
    }

    public void OnLight()
    {
        isLightOn = isLightOn?false:true;
        if (isLightOn) PhoneLight.SetActive(true);
        else PhoneLight.SetActive(false);
    }

    public void OnGuide()
    {
        CurrentState = state.Guide;
    }

    public void Setting()
    {
        CurrentState = state.Setting;
    }
}

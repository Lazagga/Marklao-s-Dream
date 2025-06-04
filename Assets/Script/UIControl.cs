using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    public static UIControl Instance;

    private void Awake()
    {
        if (null == Instance)
        {
            UIControl.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    } 

    public bool isPhoneUp;
    private bool isLightOn;
    private bool isSettingChanged;

    public float curSense;
    public float curFov;

    public Slider Sense;
    public Slider Fov;
    public TMP_Text SenseT;
    public TMP_Text FovT;

    private Vector2 DownPos = new Vector2(100, -400);
    private Vector2 UpPos = new Vector2(100, 0);

    public Image Phone;
    public GameObject[] PhoneUI;
    public GameObject CautionPopup;
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
        isSettingChanged = false;
        CautionPopup.SetActive(false);

        CurrentState = state.Idle;

        curSense = 1;
        curFov = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isPhoneUp)
            {
                isPhoneUp = true;
                StopCoroutine("PhoneDown");
                StartCoroutine("PhoneUp");
            }
            else
            {
                if (isSettingChanged)
                {
                    CautionPopup.SetActive(true);
                }
                else
                {
                    StopCoroutine("PhoneUp");
                    StartCoroutine("PhoneDown");
                    isPhoneUp = false;
                }
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

        if(CurrentState == state.Setting)
        {
            SenseT.text = "" + Sense.value / 10;
            FovT.text = "" + Fov.value;
        }
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

    public void OnSettingChanged()
    {
        isSettingChanged = true;
    }

    public void OnSave()
    {
        isSettingChanged = false;
        curSense = Sense.value / 10;
        curFov = Fov.value;
        isPhoneUp = false;
        StopCoroutine("PhoneUp");
        StartCoroutine("PhoneDown");
    }

    public void OnCautionQuit()
    {
        Sense.value = curSense*10;
        Fov.value = curFov;
        isSettingChanged = false;
        isPhoneUp = false;
        StopCoroutine("PhoneUp");
        StartCoroutine("PhoneDown");
        CautionPopup.SetActive(false);
    }

    public void OnCautionRemain()
    {
        CautionPopup.SetActive(false);
    }
}

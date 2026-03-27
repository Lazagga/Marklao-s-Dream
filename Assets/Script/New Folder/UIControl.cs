using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    public static UIControl Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool isPhoneUp;
    public bool isEvent;
    private bool isLightOn;
    private bool isSettingChanged;

    public float curSense;
    public float curFov;

    public Slider Sense;
    public Slider Fov;
    public TMP_Text SenseT;
    public TMP_Text FovT;

    private readonly Vector2 DownPos = new(100, -400);
    private readonly Vector2 UpPos = new(100, 0);

    public Image fade;
    public Image Phone;
    public GameObject[] PhoneUI;
    public GameObject CautionPopup;
    public GameObject PhoneLight;

    public float animTime = 1f;

    public enum PhoneState { Idle, Call, Guide, Setting }
    public PhoneState CurrentState;

    private Coroutine phoneCoroutine;

    public void UpdateCanvas()
    {
        foreach (var canvas in PhoneUI) canvas.SetActive(false);
        switch (CurrentState)
        {
            case PhoneState.Call:    PhoneUI[0].SetActive(true); break;
            case PhoneState.Guide:   PhoneUI[1].SetActive(true); break;
            case PhoneState.Setting: PhoneUI[2].SetActive(true); break;
        }
    }

    private void Start()
    {
        isLightOn = false;
        isSettingChanged = false;
        CautionPopup.SetActive(false);
        CurrentState = PhoneState.Idle;
        curSense = 1;
        curFov = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isPhoneUp)
            {
                isPhoneUp = true;
                SetPhoneCoroutine(PhoneUp());
            }
            else if (!isEvent)
            {
                if (isSettingChanged)
                {
                    CautionPopup.SetActive(true);
                }
                else if (CurrentState != PhoneState.Call)
                {
                    isPhoneUp = false;
                    SetPhoneCoroutine(PhoneDown());
                }
            }
        }

        if (isPhoneUp)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            CurrentState = PhoneState.Idle;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        UpdateCanvas();

        if (CurrentState == PhoneState.Setting)
        {
            SenseT.text = (Sense.value / 10).ToString();
            FovT.text = Fov.value.ToString();
        }
    }

    private void SetPhoneCoroutine(IEnumerator routine)
    {
        if (phoneCoroutine != null) StopCoroutine(phoneCoroutine);
        phoneCoroutine = StartCoroutine(routine);
    }

    public IEnumerator PhoneUp()
    {
        float pastTime = 0f;
        while (pastTime < animTime)
        {
            Phone.rectTransform.anchoredPosition = Vector2.Lerp(
                Phone.rectTransform.anchoredPosition, UpPos, pastTime / animTime);
            pastTime += Time.deltaTime;
            yield return null;
        }
        Phone.rectTransform.anchoredPosition = UpPos;
    }

    private IEnumerator PhoneDown()
    {
        float pastTime = 0f;
        while (pastTime < animTime)
        {
            Phone.rectTransform.anchoredPosition = Vector2.Lerp(
                Phone.rectTransform.anchoredPosition, DownPos, pastTime / animTime);
            pastTime += Time.deltaTime;
            yield return null;
        }
        Phone.rectTransform.anchoredPosition = DownPos;
    }

    public void OnCall()
    {
        CurrentState = PhoneState.Call;
        StartCoroutine(CheckCall());
    }

    public IEnumerator CheckCall()
    {
        float pastTime = 0f;
        Color color = fade.color;
        while (pastTime < 3f)
        {
            color.a = pastTime / 3f;
            fade.color = color;
            pastTime += Time.deltaTime;
            yield return null;
        }

        if (GameManager.Instance.isSuccess)
        {
            // When player SUCCEEDED
        }
        else
        {
            // When player FAILED
        }
    }

    public void OnLight()
    {
        isLightOn = !isLightOn;
        PhoneLight.SetActive(isLightOn);
    }

    public void OnGuide()
    {
        CurrentState = PhoneState.Guide;
    }

    public void Setting()
    {
        CurrentState = PhoneState.Setting;
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
        SetPhoneCoroutine(PhoneDown());
    }

    public void OnCautionQuit()
    {
        Sense.value = curSense * 10;
        Fov.value = curFov;
        isSettingChanged = false;
        isPhoneUp = false;
        CautionPopup.SetActive(false);
        SetPhoneCoroutine(PhoneDown());
    }

    public void OnCautionRemain()
    {
        CautionPopup.SetActive(false);
    }
}

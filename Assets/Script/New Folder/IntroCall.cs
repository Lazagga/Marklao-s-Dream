using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroCall : MonoBehaviour
{
    public TMP_Text Script;
    public GameObject calling;
    public Button Call;

    private string[] Scripts = new string[]
    {
        "진짜 오랜만에 신입이네",
        "잘 부탁까지는.... 모르겠고, 일단은 인수인계 해야해서",
        "어, 할일은 간단해. 방 안에 들어가면 표지판이 있을거야",
        "그 표지판이 시키는 대로 하면된다,\n아무리 그게 이상한 내용이더라도 말이야.",
        "간단하지?",
        "아 그리고 가끔씩 표지판이 불가능한 명령을 내릴 때가 있어",
        "그럴 때는 내가 보내준 회선으로 전화를 걸고 눈을 감아,\n그리고 절대로 눈을 뜨지 마",
        "이해했지? 그럼 이만 난 퇴근한다"
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Script.enabled = false;
        UIControl.Instance.isEvent = true;
        UIControl.Instance.isPhoneUp = true;
        StartCoroutine(UIControl.Instance.PhoneUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrintScript(string[] S)
    {
        foreach (string T in S)
        {
            yield return StartCoroutine(PrintText(T));
            yield return new WaitForSeconds(1f);
            Script.text = string.Empty;
        }
        UIControl.Instance.isEvent = false;
        calling.SetActive(false);
    }

    IEnumerator PrintText(string T)
    {
        for (int i = 0; i < T.Length; i++)
        {
            Script.text += T[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnCalling()
    {
        Script.enabled = true;
        Call.enabled = false;
        StartCoroutine(PrintScript(Scripts));
    }
}

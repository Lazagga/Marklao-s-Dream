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
        "��¥ �������� �����̳�",
        "�� ��Ź������.... �𸣰ڰ�, �ϴ��� �μ��ΰ� �ؾ��ؼ�",
        "��, ������ ������. �� �ȿ� ���� ǥ������ �����ž�",
        "�� ǥ������ ��Ű�� ��� �ϸ�ȴ�,\n�ƹ��� �װ� �̻��� �����̴��� ���̾�.",
        "��������?",
        "�� �׸��� ������ ǥ������ �Ұ����� ����� ���� ���� �־�",
        "�׷� ���� ���� ������ ȸ������ ��ȭ�� �ɰ� ���� ����,\n�׸��� ����� ���� ���� ��",
        "��������? �׷� �̸� �� ����Ѵ�"
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

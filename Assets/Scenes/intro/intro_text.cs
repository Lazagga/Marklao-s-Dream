using System.Collections;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class intro_text : MonoBehaviour
{
    public Transform Text;
    TextMeshProUGUI TextMeshPro;
    public Transform Fade;
    Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text = this.transform.Find("script");
        TextMeshPro = Text.GetComponent<TextMeshProUGUI>();

        Fade = this.transform.Find("fade");
        image = Fade.GetComponent<Image>();

        StartCoroutine(intro_massage());
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    string sentence1 = "�λ����� ���� �߿��� ���� �ٸ� �ƴ� ���̴�. \r\n" +
        "�׷��� �״��� �Ḣ�� ������ ���� ����� �ƴϾ��⿡, ���� ���� ���� ���ؼ� �� �� �ִ� ���� �״��� ���� �ʾҴ�. \r\n\r\n" +
        "��ü �뵿�� �����, �ҹ����� ���� �������� ���� ũ���� �ʴ�. \r\n" +
        "�׷��� ����� ���� ���� ���ϴ� ���� ã�� �Ǿ���. \r\n\r\n" +
        "���� �ð��� �ϴ� ��� ȸ���� �߰� ���, �̻��� ���� �ƴϰ���.\r\n\r\n";

    string[] sentence2 = new string[] { 
        "�׷��� ����� �ʹ� �ܰ��� �� ������", 
        "���� �ð��̱� �ѵ�, �ǹ��� ���� ���ε� �����ݾ�.", 
        "...�� �ǹ��̰���? �ֺ��� �ǹ��� �����ϱ�?" };


    string[] sentence3 = new string[]
    {
        "�� ���ͺ��� ����� ����, �ڵ����� ����. ��ġ�� ���Ⱑ �´µ�",
        "�ǹ��� �� ������ ũ��",
        "...�ϴ� ������, ���� ������ ���޹޾����ϱ�",
        "�� ���� ������ ���̳� ����."
    };

    IEnumerator intro_massage()
    {

        //1. ���ھ� ���
        string str = string.Empty;
        for(int i = 0; i < sentence1.Length; i++)
        {
            TextMeshPro.text = str;
            str += sentence1[i];
            yield return new WaitForSeconds(0.05f);
        }

        //2. ȭ�� ���̵� ��
        //start�� ���� ��
        //end�� ���� ������ a(alpha)�� 0
        float duration = 1.0f;
        float time = 0f;

        Color startColor_fade = image.color;
        Color endColor_fade = startColor_fade; endColor_fade.a = 0f;

        Color startColor_text = TextMeshPro.color;
        Color endColor_text = startColor_text; endColor_text.a = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            image.color = Color.Lerp(startColor_fade, endColor_fade, time / duration);        //0�̸� ����, 1�̸� ������
            TextMeshPro.color = Color.Lerp(startColor_text, endColor_text, time / duration);
            yield return null;
        }

        image.color = endColor_fade;
        TextMeshPro.color = endColor_text;


        //3. �÷��̾� ���
        Text.transform.Translate(0.0f, -650.0f, 0.0f);
        TextMeshPro.text = string.Empty;
        TextMeshPro.color = startColor_text;
        for(int i = 0; i < 3; i++)
        {
            TextMeshPro.text = sentence2[i];
            yield return new WaitForSeconds(3f);
        }

        TextMeshPro.text = string.Empty;


        yield return new WaitForSeconds(20f);       //�÷��̾� ������ ���

        //4. �ǹ� �� ���� �� ���
        for (int i = 0; i < 4; i++)
        {
            TextMeshPro.text = sentence3[i];
            yield return new WaitForSeconds(3f);
        }

        //5. ���̵� �ƿ�
        time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            image.color = Color.Lerp(endColor_fade, startColor_fade, time / duration);      
            yield return null;
        }
    }
    
}

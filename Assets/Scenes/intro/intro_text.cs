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
    string sentence1 = "인생에서 가장 중요한 것은 다름 아닌 돈이다. \r\n" +
        "그러나 그다지 휼륭한 스펙을 가진 사람이 아니었기에, 많은 돈을 벌기 위해서 할 수 있는 일은 그다지 많지 않았다. \r\n\r\n" +
        "육체 노동은 힘들고, 불법적인 일을 할정도로 담이 크지는 않다. \r\n" +
        "그러던 어느날 드디어 내가 원하는 일을 찾게 되었다. \r\n\r\n" +
        "늦은 시간에 하는 어느 회사의 야간 경비, 이상한 일은 아니겠지.\r\n\r\n";

    string[] sentence2 = new string[] { 
        "그런데 여기는 너무 외곽인 것 같은데", 
        "늦은 시간이긴 한데, 건물도 없고 가로등 뿐이잖아.", 
        "...저 건물이겠지? 주변의 건물이 없으니까?" };


    string[] sentence3 = new string[]
    {
        "뭐 나와보는 사람도 없고, 자동차도 없고. 위치는 여기가 맞는데",
        "건물은 또 더럽게 크네",
        "...일단 들어가보자, 업무 내용은 전달받았으니까",
        "일 빨리 끝내고 돈이나 받자."
    };

    IEnumerator intro_massage()
    {

        //1. 한자씩 출력
        string str = string.Empty;
        for(int i = 0; i < sentence1.Length; i++)
        {
            TextMeshPro.text = str;
            str += sentence1[i];
            yield return new WaitForSeconds(0.05f);
        }

        //2. 화면 페이드 인
        //start가 원래 색
        //end는 원래 색에서 a(alpha)만 0
        float duration = 1.0f;
        float time = 0f;

        Color startColor_fade = image.color;
        Color endColor_fade = startColor_fade; endColor_fade.a = 0f;

        Color startColor_text = TextMeshPro.color;
        Color endColor_text = startColor_text; endColor_text.a = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            image.color = Color.Lerp(startColor_fade, endColor_fade, time / duration);        //0이면 왼쪽, 1이면 오른쪽
            TextMeshPro.color = Color.Lerp(startColor_text, endColor_text, time / duration);
            yield return null;
        }

        image.color = endColor_fade;
        TextMeshPro.color = endColor_text;


        //3. 플레이어 대사
        Text.transform.Translate(0.0f, -650.0f, 0.0f);
        TextMeshPro.text = string.Empty;
        TextMeshPro.color = startColor_text;
        for(int i = 0; i < 3; i++)
        {
            TextMeshPro.text = sentence2[i];
            yield return new WaitForSeconds(3f);
        }

        TextMeshPro.text = string.Empty;


        yield return new WaitForSeconds(20f);       //플레이어 움직임 대기

        //4. 건물 앞 도착 후 대사
        for (int i = 0; i < 4; i++)
        {
            TextMeshPro.text = sentence3[i];
            yield return new WaitForSeconds(3f);
        }

        //5. 페이드 아웃
        time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            image.color = Color.Lerp(endColor_fade, startColor_fade, time / duration);      
            yield return null;
        }
    }
    
}

using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class intro_move_car : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool car_move = true;
    void Start()
    {
        car_move = true;
        StartCoroutine(goto_apart());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    IEnumerator goto_apart()
    {
        while (true)
        {
            transform.Translate(0.05f, 0.0f, 0.0f);
            yield return null;
            if(transform.position.x > 60.0f)
                break;
        }

        yield return new WaitForSeconds(1.5f);


        //회전해서 주차
        for(int i = 0; i< 900; i++)
        {
            transform.Rotate(0.0f, 0.1f, 0.0f);
            transform.Translate(0.03f, 0.0f, 0.0f);
            yield return null;
        }
        for(int i = 60; i > 0; i--)                 
        {
            transform.Translate(0.06f, 0.0f, 0.0f);
            yield return null;
        }

        yield return new WaitForSeconds(1f);        //잠시 대기후

        for (int i = 0; i < 800; i++)               //차문 열기
        {
            transform.Find("door").Rotate(0.0f, 0.0f, 0.1f);
            yield return null;
        }

        car_move = false;       //차 움직임 끝
    }
}

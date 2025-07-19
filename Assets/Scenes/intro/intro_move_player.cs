using NUnit.Framework.Constraints;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class intro_move_player : MonoBehaviour
{
    public GameObject car;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.SetParent(car.transform);
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        //float view = Input.GetAxisRaw("Mouse X");

        //transform.Rotate(0, view, 0);
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => car.GetComponent<intro_move_car>().car_move == false);      //차 움직임이 끝나면
        yield return new WaitForSeconds(1f);

        transform.parent = null;    //부모 해제

        Debug.Log("마지막 각도가 " + transform.rotation.eulerAngles);

        Quaternion now = transform.rotation;
        Quaternion move = Quaternion.Euler(0.0f, 75.0f, 0.0f);      //now를 곱해야 현재 기준 +90으로 이동

        float t = 0.0f; //0이면 now -> 1이면 move로
        float dur = 1.0f;

        //현재 시점에서 건물 바라보고
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(now, move, t);
            yield return null;
        }

        transform.rotation = move;

        //차에서 내리고
        for (int i = 0; i < 250; i++)          //z만 마이너스로
        {
            transform.Translate(0f, -0.001f, 0.005f);
            yield return null;
        }
        for (int i = 0; i < 250; i++)
        {
            transform.Translate(0f, 0.001f, 0.001f);
            yield return null;
        }


        // -> 건물 앞으로 이동
        for (int j = 0; j < 8; j++)          //x방향 -, z방향 +      
        {
            if(j % 2 == 0)
            {
                for (int i = 0; i < 250; i++)
                {
                    transform.Translate(-0.01f, -0.002f, 0.011f);
                    yield return null;
                }
            }
            else
            {
                for (int i = 0; i < 250; i++)
                {
                    transform.Translate(-0.01f, 0.002f, 0.011f);
                    yield return null;
                }
            }
        }

        //정면 보고
        t = 0.0f;
        now = transform.rotation;
        move = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(now, move, t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);


        //왼쪽보고
        t = 0.0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(move, Quaternion.Euler(0.0f, 25.0f, 0.0f), t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //오른쪽보고
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 25.0f, 0.0f), Quaternion.Euler(0.0f, 165.0f, 0.0f), t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //다시 정면
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 165.0f, 0.0f), move, t);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        //하늘 보고
        t = 0.0f;
        now = transform.rotation;
        move = now * Quaternion.Euler(-45.0f, 0.0f, 0.0f);
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(now, move, t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //다시 아래 보고
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(move, now, t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //건물 안으로
        for (int j = 0; j < 8; j++)          //x방향 -, z방향 +      
        {
            if (j % 2 == 0)
            {
                for (int i = 0; i < 250; i++)
                {
                    transform.Translate(0.0f, -0.002f, 0.011f);
                    yield return null;
                }
            }
            else
            {
                for (int i = 0; i < 250; i++)
                {
                    transform.Translate(0.00f, 0.002f, 0.011f);
                    yield return null;
                }
            }
        }





    }


}

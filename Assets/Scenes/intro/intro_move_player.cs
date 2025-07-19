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
        yield return new WaitUntil(() => car.GetComponent<intro_move_car>().car_move == false);      //�� �������� ������
        yield return new WaitForSeconds(1f);

        transform.parent = null;    //�θ� ����

        Debug.Log("������ ������ " + transform.rotation.eulerAngles);

        Quaternion now = transform.rotation;
        Quaternion move = Quaternion.Euler(0.0f, 75.0f, 0.0f);      //now�� ���ؾ� ���� ���� +90���� �̵�

        float t = 0.0f; //0�̸� now -> 1�̸� move��
        float dur = 1.0f;

        //���� �������� �ǹ� �ٶ󺸰�
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(now, move, t);
            yield return null;
        }

        transform.rotation = move;

        //������ ������
        for (int i = 0; i < 250; i++)          //z�� ���̳ʽ���
        {
            transform.Translate(0f, -0.001f, 0.005f);
            yield return null;
        }
        for (int i = 0; i < 250; i++)
        {
            transform.Translate(0f, 0.001f, 0.001f);
            yield return null;
        }


        // -> �ǹ� ������ �̵�
        for (int j = 0; j < 8; j++)          //x���� -, z���� +      
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

        //���� ����
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


        //���ʺ���
        t = 0.0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(move, Quaternion.Euler(0.0f, 25.0f, 0.0f), t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //�����ʺ���
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 25.0f, 0.0f), Quaternion.Euler(0.0f, 165.0f, 0.0f), t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //�ٽ� ����
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 165.0f, 0.0f), move, t);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        //�ϴ� ����
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

        //�ٽ� �Ʒ� ����
        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / dur;
            transform.rotation = Quaternion.Slerp(move, now, t);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        //�ǹ� ������
        for (int j = 0; j < 8; j++)          //x���� -, z���� +      
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

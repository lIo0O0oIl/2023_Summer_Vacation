using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class SpeedTest : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StringDemoFunc();
        }
    }

    private void StringDemoFunc()
    {
        // ��Ʈ�� VS ��Ʈ�� ������ �ӵ� �׽�Ʈ (+ �޸� ���� ��)

        string s = "";
        StringBuilder sb = new StringBuilder();

        Debug.Log($"StartTime : {DateTime.Now.ToLongTimeString()}");    // ������ �ð� ������

        for (int i = 0; i < 100000; i++)
        {
            //s += "Hi ";
            sb.Append("Hi ");
        }

        Debug.Log($"EndTime : {DateTime.Now.ToLongTimeString()}");

        //Debug.Log(s);         // 1�аɸ�
        Debug.Log(sb.ToString());       // 1�ʵ� �Ȱɸ�. ���
    }
}

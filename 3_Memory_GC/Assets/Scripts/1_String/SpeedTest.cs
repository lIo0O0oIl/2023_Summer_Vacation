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
        // 스트링 VS 스트링 빌러의 속도 테스트 (+ 메모리 차지 비교)

        string s = "";
        StringBuilder sb = new StringBuilder();

        Debug.Log($"StartTime : {DateTime.Now.ToLongTimeString()}");    // 현재의 시간 보여줌

        for (int i = 0; i < 100000; i++)
        {
            //s += "Hi ";
            sb.Append("Hi ");
        }

        Debug.Log($"EndTime : {DateTime.Now.ToLongTimeString()}");

        //Debug.Log(s);         // 1분걸림
        Debug.Log(sb.ToString());       // 1초도 안걸림. 우왕
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfmoanceTesting : MonoBehaviour
{
    const int numberOfTests = 5000;

    Transform testTrm;

    private void PerformanceTest1()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = GetComponent<Transform>();
        }
    }

    private void PerformanceTest2()
    {
        for(int i = 0;i < numberOfTests; i++)
        {
            //testTrm = (Transform)GetComponent("Transform");
            testTrm = GetComponent("Transform").transform;
        }
    }

    private void PerformanceTest3()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = (Transform)GetComponent(typeof(Transform));
        }
    }

    private void Update()
    {
        PerformanceTest1();
        PerformanceTest2();
        PerformanceTest3();
    }
}

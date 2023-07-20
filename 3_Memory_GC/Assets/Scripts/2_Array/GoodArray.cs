using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodArray : MonoBehaviour
{
    float[] randResultVal;

    private void Start()
    {
        randResultVal = new float[10000];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomList(randResultVal);
        }
    }

    private void RandomList(float[] arrayToFill)
    {
        for (int i = 0; i < arrayToFill.Length; i++)
        {
            arrayToFill[i] = Random.value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadArray : MonoBehaviour
{
    float[] randResultVal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randResultVal = RandomList(10000);
        }
    }

    private float[] RandomList(int numberElements)
    {
        var result = new float[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            result[i] = Random.value;
        }

        return result;
    }
}

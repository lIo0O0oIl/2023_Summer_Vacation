using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GoodString : MonoBehaviour
{
    string[] testStr = { "a", "b", "c", "d", "e" };

    private StringBuilder _sb = new StringBuilder();

    private void Start()
    {
        _sb.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 1000; i++)
            {
                ConcatExample(testStr);
            }
        }
    }

    string ConcatExample(string[] strArry)
    {
        _sb.Clear();

        for (int i = 0; i < strArry.Length; i++)
        {
            _sb.Append(strArry[i]);
        }

        return _sb.ToString();
    }
}

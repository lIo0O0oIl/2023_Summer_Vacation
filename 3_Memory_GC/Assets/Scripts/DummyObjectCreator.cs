using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int numberOfObjects;

    GameObject dummyObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObject();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DestroyObjects();
        }
    }

    void CreateObject()
    {
            for (int i = 0; i < numberOfObjects; i++)
            {
            dummyObj = new GameObject("A_Dummy");
            dummyObj.tag = "Player";
            }
    }

    void DestroyObjects()
    {
        GameObject[] dummyObjs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in dummyObjs)
        {
            Destroy(go);
            //DestroyImmediate(go);   // 즉시 지워준다.
        }
    }
}

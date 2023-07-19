using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int numberOfObjects;

    GameObject dummyObj;

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
        }
    }
}

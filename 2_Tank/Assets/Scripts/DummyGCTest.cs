using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이거 잘못짜심

public class DummyGCTest : MonoBehaviour
{
    void Update()
    {
        CreateTanks();
        DestroyTanks();
    }

    private void CreateTanks()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject tankObj = new GameObject();
        }
    }

    private void DestroyTanks()
    {
        GameObject[] tankObjs = GameObject.FindGameObjectsWithTag("tank");
        for (int i = 0;i < 100; i++)
        {
            Destroy(tankObjs[i]);
        }
    }

}

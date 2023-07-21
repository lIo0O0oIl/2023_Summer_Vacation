using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 클래스, 구조체
 */

// 유지보수가 어려움. 값 복사가로만 됨(참조복사 X)
public struct NPCStruct
{
    public GameObject avatar;
    public string name;
    public int health;      // 8비트(1바이트) 씩 24개

    public NPCStruct(string _name, GameObject go)
    {
        name = _name;
        health = 100;
        avatar = go;
    }
}

public class NPCClass
{
    public GameObject avatar;
    public string name;
    public int health;      // 24bit 하고도 참조공간으로 32bit 가 됨

    public NPCClass(string _name, GameObject go)
    {
        name = _name;
        health = 100;
        avatar = go;
    }
}

public class NPCTypes : MonoBehaviour
{
    const int numberOfTests = 100000;
    NPCStruct[] npcs = new NPCStruct[numberOfTests];
    NPCClass[] npcc = new NPCClass[numberOfTests];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateStructs();
            CreateClasses();
        }

        // 함수 전달
        if (Input.GetKeyDown(KeyCode.P))
        {
            PassStructs();
            PassClasses();
        }
    }

    void UseStruct(NPCStruct npc)
    {
    }

    void PassStructs()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseStruct(npcs[i]);     // 값복사
        }
    }

    void UseClass(NPCClass npc)
    {
    }

    void PassClasses()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseClass(npcc[i]);      // 참조
        }
    }

    private void CreateStructs()
    {
        //var npcs = new NPCStruct[numberOfTest]; // C# 에서만 구조체 new 가능
        for (int i = 0; i < numberOfTests; i++)
        {
            npcs[i] = new NPCStruct("유준무쌤", null);
        }
    }

    private void CreateClasses()
    {
        //var npcc = new NPCClass[numberOfTest]; // C# 에서만 구조체 new 가능
        for (int i = 0; i < numberOfTests; i++)
        {
            npcc[i] = new NPCClass("유준무쌤", null);
        }
    }
}

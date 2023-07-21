using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Ŭ����, ����ü
 */

// ���������� �����. �� ���簡�θ� ��(�������� X)
public struct NPCStruct
{
    public GameObject avatar;
    public string name;
    public int health;      // 8��Ʈ(1����Ʈ) �� 24��

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
    public int health;      // 24bit �ϰ� ������������ 32bit �� ��

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

        // �Լ� ����
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
            UseStruct(npcs[i]);     // ������
        }
    }

    void UseClass(NPCClass npc)
    {
    }

    void PassClasses()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseClass(npcc[i]);      // ����
        }
    }

    private void CreateStructs()
    {
        //var npcs = new NPCStruct[numberOfTest]; // C# ������ ����ü new ����
        for (int i = 0; i < numberOfTests; i++)
        {
            npcs[i] = new NPCStruct("���ع���", null);
        }
    }

    private void CreateClasses()
    {
        //var npcc = new NPCClass[numberOfTest]; // C# ������ ����ü new ����
        for (int i = 0; i < numberOfTests; i++)
        {
            npcc[i] = new NPCClass("���ع���", null);
        }
    }
}

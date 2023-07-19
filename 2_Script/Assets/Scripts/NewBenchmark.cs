using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBenchmark : MonoBehaviour
{
    public int numberOfSpheres = 100;

    Transform[] spheres;

    void Start()
    {
        spheres = new Transform[numberOfSpheres];

        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer rend = sphereObj.GetComponent<Renderer>();
            rend.material = new Material(Shader.Find("Specular"));
            rend.material.color = Color.red;
            sphereObj.transform.position = Random.insideUnitSphere * 20;
            spheres[i] = sphereObj.transform;
        }
    }

    void Update()
    {
        // Ű�Է��� �޾Ƽ� ��ü ���Ǿ �̵���Ŵ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform t in spheres)        // for ���� �� ����
            {
                t.Translate(0, 0, 1f);      // �̰ͺ��� ���͸� �����ִ� ���� 0.2�� ���� �� ����
            }
        }
    }
}

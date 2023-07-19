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
        // 키입력을 받아서 전체 스피어를 이동시킴
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform t in spheres)        // for 문이 더 빠름
            {
                t.Translate(0, 0, 1f);      // 이것보다 백터를 더해주는 것이 0.2초 정도 더 빠름
            }
        }
    }
}

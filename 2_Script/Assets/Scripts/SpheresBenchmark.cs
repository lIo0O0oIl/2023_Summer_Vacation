using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresBenchmark : MonoBehaviour
{
    public int numberOfSpheres = 100;

    void Start()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
           GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer rend = sphereObj.GetComponent<Renderer>();
            rend.material = new Material(Shader.Find("Specular"));
            rend.material.color = Color.red;
            sphereObj.transform.position = Random.insideUnitSphere * 20;
        }
    }

    void Update()
    {
        // 키입력을 받아서 전체 스피어를 이동시키는 코딩을 해본다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform t in spheres)
            {
                t.Translate(0, 0, 1f);
            }
        }
    }
}

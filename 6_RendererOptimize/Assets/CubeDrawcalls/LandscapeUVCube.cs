using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeUVCube : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public int width = 100;
    public int depth = 100;

    GameObject cubeParantObj;

    void Start()
    {
        CreateCubes();

        // 매쉬 통합 함수 호출
        CombileAll();

        //StaticBatchingUtility.Combine(this.gameObject);     // 스테틱 배칭 해줌
    }

    void CreateCubes()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float height = Mathf.PerlinNoise(x / 50f, z / 50f) * 50 + Mathf.PerlinNoise((x + 25) / 30f, (z + 25) / 30f) * 50;

                Vector3 pos = new Vector3(x, height, z);
                if (height > 60)
                    cubeParantObj = Instantiate(block1, pos, Quaternion.identity);
                else if (height > 50)
                    cubeParantObj = Instantiate(block2, pos, Quaternion.identity);
                else if (height > 30)
                    cubeParantObj = Instantiate(block3, pos, Quaternion.identity);
                else
                    cubeParantObj = Instantiate(block4, pos, Quaternion.identity);

                cubeParantObj.transform.SetParent(this.transform);
            }
        }
    }

    private void CombileAll()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combines = new CombineInstance[meshFilters.Length - 1];

        // 개별 매쉬를 공용메쉬로 묶어주기
        int i = 1;
        while (i < meshFilters.Length)
        {
            combines[i - 1].mesh = meshFilters[i].sharedMesh;
            combines[i - 1].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        // 하나의 통합된 메쉬만 켜주기
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combines);
        transform.gameObject.SetActive(true);
    }

}

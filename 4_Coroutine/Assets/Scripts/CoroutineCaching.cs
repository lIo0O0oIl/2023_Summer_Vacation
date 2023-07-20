using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;   // ��� ��ġ ����
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    /*
     �⺻ �ڷ�ƾ VS ĳ�� �ڷ�ƾ
     */

    public int maxSpawnCount = 100;
    public float spawnDelay = 0.1f;
    public GameObject cubeObjPrefab;

    // �ڷ�ƾ ���� ������
    private int spawnCount;
    private Vector3 randomPos;
    private GameObject newCube;

    // �ڷ�ƾ ĳ�� �߰�
    private WaitForSeconds spawnWFS;
    private Coroutine spawnCoVal;       // �ڷ�ƾ �ߺ� ���� ���� �ϰ�

    // �ӵ� üũ ���� ����
    Stopwatch stopwatch = new Stopwatch();

    private void Start()
    {
        spawnWFS = new WaitForSeconds(spawnDelay);

        spawnCoVal = null;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (spawnCoVal == null)     // ���� �ڷ�ƾ���� ĳ�� ��    �� ����ɶ����� �ٽ� �ȴ���
            {
                spawnCoVal = StartCoroutine(SpawnCo());
            }
        }
    }

    IEnumerator SpawnCo()
    {
        Debug.Log("ť�� ���� �׽�Ʈ ����");

        // �����ϴ� ��� �ڽ� ť�� ����
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        stopwatch.Reset();
        stopwatch.Start();

        spawnCount = maxSpawnCount;
        while (spawnCount > 0)
        {
            randomPos = new Vector3(Random.value, Random.value, Random.value);
            newCube = Instantiate(cubeObjPrefab, randomPos, Quaternion.identity);
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            newCube.transform.SetParent(this.transform);

            yield return new WaitForSeconds(spawnDelay);
            //yield return spawnWFS;

            spawnCount--;
        }

        stopwatch.Stop();
        spawnCoVal = null;

        Debug.Log(string.Format("{0}�� �ɸ�", stopwatch.ElapsedMilliseconds / 1000));
    }
}

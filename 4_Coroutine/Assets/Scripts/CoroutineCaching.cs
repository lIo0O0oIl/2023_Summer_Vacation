using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;   // 통계 수치 관련
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    /*
     기본 코루틴 VS 캐싱 코루틴
     */

    public int maxSpawnCount = 100;
    public float spawnDelay = 0.1f;
    public GameObject cubeObjPrefab;

    // 코루틴 관련 변수들
    private int spawnCount;
    private Vector3 randomPos;
    private GameObject newCube;

    // 코루틴 캐싱 추가
    private WaitForSeconds spawnWFS;
    private Coroutine spawnCoVal;       // 코루틴 중복 실행 ㄴㄴ 하게

    // 속도 체크 관련 변수
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
            if (spawnCoVal == null)     // 개별 코루틴으로 캐싱 완    다 실행될때까지 다시 안눌림
            {
                spawnCoVal = StartCoroutine(SpawnCo());
            }
        }
    }

    IEnumerator SpawnCo()
    {
        Debug.Log("큐브 생성 테스트 시작");

        // 존재하는 모든 자식 큐브 삭제
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

        Debug.Log(string.Format("{0}초 걸림", stopwatch.ElapsedMilliseconds / 1000));
    }
}

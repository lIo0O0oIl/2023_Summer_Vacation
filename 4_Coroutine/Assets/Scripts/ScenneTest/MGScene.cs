using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

/*
    싱글톤 클래스
*/

public enum eSceneName
{
    None = -1,
    Loading,
    Logo,
    Title,
    Game
}

public class MGScene : MonoBehaviour
{
    // 씬 매니져

    private static MGScene _instance;
    public static MGScene Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MGScene)) as MGScene;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;      // 이건 하이어라키 창에서 숨길 수 있음. 내부에서만 돌아가면 되거든
                    _instance = obj.AddComponent<MGScene>();
                }
            }

            return _instance;
        }
    }

    private StringBuilder _sb;

    private eSceneName _curScene/*, _beforeScene*/;
    private Transform uiRootTrm;    // 모든 UI 의 기초가 되는 캔버스
    private Transform addUiTrm;     // Root 밑에 추가되는 각 씬과 일대일로 매칭되는 ui

    // ui 장면별 프리탭 연결 용도(하드코딩)
    public GameObject uiRootPrefab;
    public GameObject loadinguiPrefab;
    public GameObject logoUiPrefab;
    public GameObject titleUiPrefab;
    public GameObject gameUiPrefab;

    public void Generate() { }      // 생성하는 용도

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _sb = new StringBuilder();

        GameObject uiRootObj = GameObject.Instantiate(uiRootPrefab) as GameObject;
        uiRootTrm = uiRootObj.transform;

        InitScene();
    }

    private void InitScene()
    {
        //_beforeScene = eSceneName.None;

        // 최초로 화면에 보여줄 장면
        ChangeScene(eSceneName.Logo);
    }

    public void ChangeScene(eSceneName inScene, bool bLoading = true)
    {
        _curScene = inScene;

        if (bLoading)
        {
            _sb.Remove(0, _sb.Length);      // claer() 보다 더 쌈
            _sb.AppendFormat("{0}Scene", eSceneName.Loading);
            SceneManager.LoadScene(_sb.ToString());
        }

        ChangeUI(eSceneName.Loading);
    }

    void ChangeUI(eSceneName inScene)
    {
        // 기존 UI 프리탭은 파괴, 속도 더 빠름
        if (addUiTrm != null)
        {
            addUiTrm.SetParent(null);
            GameObject.Destroy(addUiTrm.gameObject);
        }

        // eSceneName 과 일대일로 매칭되는 ui들을 로드 해본다. (하드코딩)
        GameObject go = null;

        if (inScene == eSceneName.Loading)
            go = GameObject.Instantiate(loadinguiPrefab) as GameObject;
        else if (inScene == eSceneName.Logo)
            go = GameObject.Instantiate(logoUiPrefab) as GameObject;
        else if (inScene == eSceneName.Title)
            go = GameObject.Instantiate(titleUiPrefab) as GameObject;
        else if (inScene == eSceneName.Game)
            go = GameObject.Instantiate(gameUiPrefab) as GameObject;

        // 좌표 초기화
        addUiTrm = go.transform;
        addUiTrm.SetParent(uiRootTrm);

        addUiTrm.localPosition = Vector3.zero;
        addUiTrm.localScale = new Vector3(1, 1, 1);

        RectTransform rts = go.GetComponent<RectTransform>();
        rts.offsetMax = new Vector2(0, 0);
        rts.offsetMin = new Vector2(0, 0);
    }

    public void LoadingDone()
    {
        //_beforeScene = _curScene;

        ChangeUI(_curScene);

        Debug.Log("로딩 끝");
    }
}

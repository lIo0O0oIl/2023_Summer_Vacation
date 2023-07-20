using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

/*
    �̱��� Ŭ����
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
    // �� �Ŵ���

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
                    obj.hideFlags = HideFlags.HideAndDontSave;      // �̰� ���̾��Ű â���� ���� �� ����. ���ο����� ���ư��� �ǰŵ�
                    _instance = obj.AddComponent<MGScene>();
                }
            }

            return _instance;
        }
    }

    private StringBuilder _sb;

    private eSceneName _curScene/*, _beforeScene*/;
    private Transform uiRootTrm;    // ��� UI �� ���ʰ� �Ǵ� ĵ����
    private Transform addUiTrm;     // Root �ؿ� �߰��Ǵ� �� ���� �ϴ��Ϸ� ��Ī�Ǵ� ui

    // ui ��麰 ������ ���� �뵵(�ϵ��ڵ�)
    public GameObject uiRootPrefab;
    public GameObject loadinguiPrefab;
    public GameObject logoUiPrefab;
    public GameObject titleUiPrefab;
    public GameObject gameUiPrefab;

    public void Generate() { }      // �����ϴ� �뵵

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

        // ���ʷ� ȭ�鿡 ������ ���
        ChangeScene(eSceneName.Logo);
    }

    public void ChangeScene(eSceneName inScene, bool bLoading = true)
    {
        _curScene = inScene;

        if (bLoading)
        {
            _sb.Remove(0, _sb.Length);      // claer() ���� �� ��
            _sb.AppendFormat("{0}Scene", eSceneName.Loading);
            SceneManager.LoadScene(_sb.ToString());
        }

        ChangeUI(eSceneName.Loading);
    }

    void ChangeUI(eSceneName inScene)
    {
        // ���� UI �������� �ı�, �ӵ� �� ����
        if (addUiTrm != null)
        {
            addUiTrm.SetParent(null);
            GameObject.Destroy(addUiTrm.gameObject);
        }

        // eSceneName �� �ϴ��Ϸ� ��Ī�Ǵ� ui���� �ε� �غ���. (�ϵ��ڵ�)
        GameObject go = null;

        if (inScene == eSceneName.Loading)
            go = GameObject.Instantiate(loadinguiPrefab) as GameObject;
        else if (inScene == eSceneName.Logo)
            go = GameObject.Instantiate(logoUiPrefab) as GameObject;
        else if (inScene == eSceneName.Title)
            go = GameObject.Instantiate(titleUiPrefab) as GameObject;
        else if (inScene == eSceneName.Game)
            go = GameObject.Instantiate(gameUiPrefab) as GameObject;

        // ��ǥ �ʱ�ȭ
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

        Debug.Log("�ε� ��");
    }
}

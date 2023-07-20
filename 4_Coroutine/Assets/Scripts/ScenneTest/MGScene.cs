using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

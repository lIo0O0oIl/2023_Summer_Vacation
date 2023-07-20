using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

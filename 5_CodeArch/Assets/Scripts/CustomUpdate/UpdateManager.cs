using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public static class UpdateManager
    {

        // 생성자
        static UpdateManager()
        {
            var gameobject = new GameObject();
            _innerMonoBehavivour = gameobject.AddComponent<UpdateManagerInnerMonoBehaviour>();
        }

        // 업데이트 전용으로 쓸 클래스
        class UpdateManagerInnerMonoBehaviour : MonoBehaviour
        {
            // 실제로 업데이트 할 객체들을 순환하며 돌려준다
            private void Update()
            {
                foreach (var mover in _updateHashs)
                {
                    mover.UpdateManager_Update();
                }
            }
        }

        static UpdateManagerInnerMonoBehaviour _innerMonoBehavivour;

        // 업데이트 매니져에서 관리할애들 목록
        static HashSet<ManagedMover> _updateHashs = new HashSet<ManagedMover>();

        public static void Add(ManagedMover mover)
        {
            _updateHashs.Add(mover);
        }

        public static void Remove(ManagedMover mover)
        {
            _updateHashs.Remove(mover);
        }
    }
}
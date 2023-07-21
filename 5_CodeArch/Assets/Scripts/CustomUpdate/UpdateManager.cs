using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public static class UpdateManager
    {

        // ������
        static UpdateManager()
        {
            var gameobject = new GameObject();
            _innerMonoBehavivour = gameobject.AddComponent<UpdateManagerInnerMonoBehaviour>();
        }

        // ������Ʈ �������� �� Ŭ����
        class UpdateManagerInnerMonoBehaviour : MonoBehaviour
        {
            // ������ ������Ʈ �� ��ü���� ��ȯ�ϸ� �����ش�
            private void Update()
            {
                foreach (var mover in _updateHashs)
                {
                    mover.UpdateManager_Update();
                }
            }
        }

        static UpdateManagerInnerMonoBehaviour _innerMonoBehavivour;

        // ������Ʈ �Ŵ������� �����Ҿֵ� ���
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
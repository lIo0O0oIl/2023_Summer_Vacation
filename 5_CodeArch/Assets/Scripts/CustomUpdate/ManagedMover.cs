using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public class ManagedMover : MonoBehaviour
    {
        float speed;

        private void Awake()
        {
            speed = Random.Range(1.0f, 1.1f);
        }

        private void OnEnable()
        {
            UpdateManager.Add(this);
        }

        private void OnDisable()
        {
            UpdateManager.Remove(this);
        }

        public void UpdateManager_Update()
        {
            MoveUpAndDown();
        }

        private void MoveUpAndDown()
        {
            var curPos = transform.position;
            transform.position = new Vector3(curPos.x, Mathf.PingPong(Time.time * speed, 10), curPos.z);
        }
    }
}
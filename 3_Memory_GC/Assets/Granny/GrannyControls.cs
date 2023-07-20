using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyControls : MonoBehaviour
{
    Animator anim;
    float speed = 0.1f;

    int animRunningID;

    void Start()
    {
        anim = GetComponent<Animator>();

        animRunningID = Animator.StringToHash("running");
        // 쉐이더에서도 쉐이더 프로퍼티 어쩌고 있음
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))     // "up" 보다는 키코드가 더 좋음 
        {
            //anim.SetBool("running", true);        // 이것보다는 헤쉬가 더 빠름
            anim.SetBool(animRunningID, true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("running", true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("running", false);
        }
    }
}

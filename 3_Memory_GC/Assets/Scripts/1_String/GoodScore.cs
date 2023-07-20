using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text scoreText;      // "Score : "   이 문자열만 들어있음

    public Text scoreDisplayText;   // 스코어 표시(숫자만)

    public int score;

    public int oldScore;

    private string scoreStr;

    void Start()
    {
        score = 99999;
        //ChangeScore();

        scoreText.text = "Score : ";
    }

    /*private void ChangeScore()
    {
        //if ((object)scoreText != null)
        //{
         //   Debug.Log("널 아님");
        //}
        if (scoreText != null)
        {
            scoreStr = "Score : " + score.ToString();
            scoreText.text = scoreStr;
        }
    }*/

    private void Update()
    {
        // 업데이트 주기를 최소화 시킨다.(if문은 값이 쌈)        저 올드 스코어는 어딘가에서 변경됨
        if (score != oldScore)
        {
            if (scoreText != null)
            {
                scoreStr = score.ToString();
                scoreDisplayText.text = scoreStr;
                oldScore = score;
                //scoreText.text = scoreStr;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            score = UnityEngine.Random.Range(1000, 10000);
        }
    }
}

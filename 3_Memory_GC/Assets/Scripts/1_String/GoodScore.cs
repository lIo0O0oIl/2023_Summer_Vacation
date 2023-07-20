using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text scoreText;      // "Score : "   �� ���ڿ��� �������

    public Text scoreDisplayText;   // ���ھ� ǥ��(���ڸ�)

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
         //   Debug.Log("�� �ƴ�");
        //}
        if (scoreText != null)
        {
            scoreStr = "Score : " + score.ToString();
            scoreText.text = scoreStr;
        }
    }*/

    private void Update()
    {
        // ������Ʈ �ֱ⸦ �ּ�ȭ ��Ų��.(if���� ���� ��)        �� �õ� ���ھ�� ��򰡿��� �����
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

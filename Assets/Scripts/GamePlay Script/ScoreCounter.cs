using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreCounter : MonoBehaviour
{


    [SerializeField]
    private Text scoreTxt;

    private int scoreCount;

    private float scoreCountTimerTreshold = 1f;
    private float scoreCountTimer;

    private bool _canCountScore;
    public bool CanCountScore
    {
        get { return _canCountScore; }
        set { _canCountScore = value; }
    }

    private StringBuilder scoreStringBuilder = new StringBuilder();

    private void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerTreshold;
    }

    private void Update()
    {
        if (!CanCountScore)
            return;

        if(Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshold;
            scoreCount++;

            DisplayScore(scoreCount);
        }
    }

    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("M");

        scoreTxt.text = scoreStringBuilder.ToString();
    }

    public int GetScore()
    {
        return scoreCount;
    }

}

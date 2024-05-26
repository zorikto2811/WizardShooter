using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    public int Score { get; set; }
    private Text scoreNumberText;

    private void Start()
    {
        scoreNumberText = GetComponent<Text>();
    }
    private void Update()
    {
        scoreNumberText.text = Score.ToString();
    }
}

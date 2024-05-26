using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter2 : MonoBehaviour
{
    private Text scoreText;
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = scoreCounter.Score.ToString();
    }

}

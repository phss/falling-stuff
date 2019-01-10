using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

    void Awake() {
       scoreText = GetComponent<Text>(); 

       GameEvents.OnNewGame += ResetScore;
       BoardEvents.OnLinesCleared += AddToScore;
    }

    private void ResetScore() {
        score = 0;
        UpdateScoreText();
    }

    private void AddToScore(int linesCleared) {
        score += linesCleared;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = score.ToString();
    }
}

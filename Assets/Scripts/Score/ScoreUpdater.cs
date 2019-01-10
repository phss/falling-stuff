using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

    private Text scoreText;
    private int level = 1;
    private int score = 0;
    private int[] scoreTable = new[] { 0, 40, 100, 300, 1200 }; 

    void Awake() {
       scoreText = GetComponent<Text>(); 

       GameEvents.OnNewGame += ResetScore;
       BoardEvents.OnLinesCleared += AddToScore;
    }

    private void ResetScore() {
        level = 1;
        score = 0;
        UpdateScoreText();
    }

    private void AddToScore(int linesCleared) {
        if (linesCleared >= scoreTable.Length) {
            linesCleared = scoreTable.Length - 1;
        }
        score += scoreTable[linesCleared] * level;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = score.ToString();
    }
}

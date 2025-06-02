using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public Text currentScoreText;
    public Text bestScoreText;

    private int currentScore = 0;
    private int bestScore = 0;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateUI();
    }

    void Update()
    {
        int heightScore = Mathf.FloorToInt(player.position.y);
        if (heightScore > currentScore)
        {
            currentScore = heightScore;
            UpdateUI();
        }
    }

    public void SaveScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    void UpdateUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = "Score: " + currentScore;

        if (bestScoreText != null)
            bestScoreText.text = "Best: " + bestScore;
    }
}

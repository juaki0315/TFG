using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void CalculateAndShowFinalScore(int remainingHearts, float elapsedTime, Text finalScoreText)
    {
        if (remainingHearts != 0)
        {
            AddPoints(remainingHearts * 10);
        }

        if (elapsedTime <= 20)
        {
            AddPoints(30);
        }
        else if (elapsedTime <= 30)
        {
            AddPoints(20);
        }
        else if (elapsedTime <= 40)
        {
            AddPoints(10);
        }
        else if (elapsedTime <= 60)
        {
            AddPoints(5);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + GetScore().ToString();
        }
    }
}

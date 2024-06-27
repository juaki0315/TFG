using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject victoryCanvas;
    public AudioClip victoryMusic;
    public Image victoryImage;
    public Text finalScoreText;

    private AudioSource audioSource;
    private AudioSource backgroundMusic;
    private ScoreManager scoreManager;
    private PlayerController playerController;
    private float gameStartTime;

    void Start()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
            audioSource = victoryCanvas.GetComponent<AudioSource>();
        }


        GameObject bgMusicController = GameObject.Find("BackgroundMusicController");
        if (bgMusicController != null)
        {
            backgroundMusic = bgMusicController.GetComponent<AudioSource>();
        }

        if (victoryImage != null)
        {
            victoryImage.gameObject.SetActive(false);
        }

        scoreManager = FindObjectOfType<ScoreManager>();

        playerController = FindObjectOfType<PlayerController>();

        gameStartTime = Time.time;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
            if (victoryImage != null)
            {
                victoryImage.gameObject.SetActive(true);
            }
            if (audioSource != null && victoryMusic != null)
            {
                if (backgroundMusic != null)
                {
                    backgroundMusic.Stop();
                }
                audioSource.clip = victoryMusic;
                audioSource.Play();
            }

            CalculateAndShowFinalScore();
        }
    }

    void CalculateAndShowFinalScore()
    {
        if (playerController != null && playerController.heartsManager != null)
        {
            if (playerController.heartsManager.currentHearts != 0)
            {
                scoreManager.AddPoints(playerController.heartsManager.currentHearts * 10);
            }
        }

        float elapsedTime = Time.time - gameStartTime;
        if (elapsedTime <= 20)
        {
            scoreManager.AddPoints(30);
        }
        else if (elapsedTime <= 30)
        {
            scoreManager.AddPoints(20);
        }
        else if (elapsedTime <= 40)
        {
            scoreManager.AddPoints(10);
        }
        else if (elapsedTime <= 60)
        {
            scoreManager.AddPoints(5);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + scoreManager.GetScore().ToString();
        }
    }
}

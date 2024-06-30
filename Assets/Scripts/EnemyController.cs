using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int health;
    public GameObject victoryCanvas;
    public AudioClip victoryMusic;
    public Image victoryImage;
    public Text finalScoreText;

    private AudioSource audioSource;
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
                audioSource.clip = victoryMusic;
                audioSource.Play();
            }

            if (scoreManager != null && playerController != null && playerController.heartsManager != null)
            {
                scoreManager.CalculateAndShowFinalScore(playerController.heartsManager.currentHearts, Time.time - gameStartTime, finalScoreText);
            }
        }
    }
}

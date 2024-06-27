using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject victoryCanvas;

    private AudioSource audioSource;
    private AudioSource backgroundMusic;

    void Start()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
            audioSource = victoryCanvas.GetComponent<AudioSource>();
        }

        GameObject bgMusicController = GameObject.Find("BackgroundMusicManager");
        if (bgMusicController != null)
        {
            backgroundMusic = bgMusicController.GetComponent<AudioSource>();
        }
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
        }
    }
}

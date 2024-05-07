using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Slider slider;

    public GameOverScreen gameOverScreen;
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void GameOver()
    {
        TogglePause();
        gameOverScreen.Setup();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void IncreaseHp(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
        Debug.Log("Health increased by " + amount + ". Current Health is: " + currentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            GameOver();
        }
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    TakeDamage(20);
        //}
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}

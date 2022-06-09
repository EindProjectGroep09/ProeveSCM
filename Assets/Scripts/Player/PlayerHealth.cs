using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    AudioController audioController;
    [SerializeField] private float health;
    public float currentHealth;
    public Slider healthBar;
    public Text healthText;

    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();

        currentHealth = health;
    }


    private void Update()
    {
        if (currentHealth > health)
        {
            currentHealth = health;
        }
        healthBar.value = currentHealth;
        healthText.text = currentHealth + "/" + health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
            audioController.gameSounds[11].Play();
        }
    }
}

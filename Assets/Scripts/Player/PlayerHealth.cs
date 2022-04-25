using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    AudioController audioController;
    [SerializeField] private float health;
    private float currentHealth;

    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();

        currentHealth = health;
    }

    private void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            audioController.gameSounds[11].Play();
            Destroy(gameObject);
        }
    }
}

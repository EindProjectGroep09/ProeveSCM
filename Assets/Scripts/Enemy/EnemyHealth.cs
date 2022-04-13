using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    private float currentHealth;
   // private Image enemyBar;
    [SerializeField]
    //private GameObject enemyUI;


    private void Start()
    {
        //enemyUI = GameObject.FindGameObjectWithTag("UI");
        ///enemyBar = enemyUI.GetComponent<Image>();
        currentHealth = health;
    }

    private void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //enemyBar.fillAmount = currentHealth / health;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

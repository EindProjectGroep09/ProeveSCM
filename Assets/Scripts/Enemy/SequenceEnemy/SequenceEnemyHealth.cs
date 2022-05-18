using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceEnemyHealth : MonoBehaviour
{
    SequenceEnemyManager SEman;
    SequenceEnemyMovement SEmove;
    SequenceEnemyTutorial SET;
    public int enemyValue; //! Blue enemy is 0,Green enemy is 1, Purple enemy is 2 Red enemy is 3

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET = FindObjectOfType<SequenceEnemyTutorial>();
        }
        SEman = FindObjectOfType<SequenceEnemyManager>();
        SEmove = FindObjectOfType<SequenceEnemyMovement>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletP1" && collision.gameObject.tag == "BulletP2")
        {
            EnemyDied();
        }
        else if (collision.gameObject.tag == "BulletP1" || collision.gameObject.tag == "BulletP2")
        {
            StartCoroutine(EnemyHit());
        }
    }
    IEnumerator EnemyHit()
    {
        SEmove.characterVelocity = 0.03f;
        yield return new WaitForSeconds(3f);
        SEmove.characterVelocity = 0.01f;
    }
    public void EnemyDied()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET.killedList.Add(enemyValue);
        }
        SEman.enemiesKilled.Add(enemyValue);
        Destroy(gameObject);
    }

}

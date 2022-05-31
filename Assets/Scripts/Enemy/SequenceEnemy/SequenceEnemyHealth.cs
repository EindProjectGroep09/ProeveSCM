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
    
    private List<Collision> hitObjectList = new List<Collision>();

    float timer = 0.5f;

    bool player1Hit = false;
    bool player2Hit = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET = FindObjectOfType<SequenceEnemyTutorial>();
        }
        SEman = FindObjectOfType<SequenceEnemyManager>();
        SEmove = FindObjectOfType<SequenceEnemyMovement>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            hitObjectList.Clear();
            timer = 0.5f;
        }
        if (hitObjectList.Count >= 2)
        {
            for (int i = 0; i < hitObjectList.Count; i++)
            {
                 if (hitObjectList[i].gameObject.tag == "BulletP1") player1Hit = true;
                if (hitObjectList[i].gameObject.tag == "BulletP2") player2Hit = true;
            }

            if (player1Hit && player2Hit)
            {
                EnemyDied();
            }
            else if (player1Hit || player2Hit)
            {
                //enemy.SwitchState(enemy.runState);
                gameObject.GetComponent<SequenceStateManager>().SwitchState(gameObject.GetComponent<SequenceStateManager>().runState);
            }
        }    
    }

    public void OnCollisionEnter(Collision collision)
    {
        hitObjectList.Add(collision);
    }

   /*     if (collision.gameObject.tag == "BulletP1" && collision.gameObject.tag == "BulletP2")
        {
            EnemyDied();
        }
        else if (collision.gameObject.tag == "BulletP1" || collision.gameObject.tag == "BulletP2")
        {
            StartCoroutine(EnemyHit());
        }*/
/*    IEnumerator EnemyHit()
    {
        SEmove.characterVelocity = 0.03f;
        yield return new WaitForSeconds(3f);
        SEmove.characterVelocity = 0.01f;
    }*/
    public void EnemyDied()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET.killedList.Add(enemyValue);
        }
        SEman.enemiesKilled.Add(enemyValue);
        Debug.Log("I died!");
        Destroy(gameObject);
    }

}

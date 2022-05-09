using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEnemyHealth : MonoBehaviour
{
    SequenceEnemyManager SEM;

    public int enemyValue; //! Blue enemy is 1, Red enemy is 0

    void Start()
    {
        SEM = FindObjectOfType<SequenceEnemyManager>();   
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletP1" && collision.gameObject.tag == "BulletP2")
        {
            EnemyDied();
        }
        else
        {
            //TODO Enemy more speed
        }
    }

    void EnemyDied()
    {
        SEM.enemiesKilled.Add(enemyValue);
        Destroy(gameObject);
    }

}

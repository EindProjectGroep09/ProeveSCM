using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEnemyHealth : MonoBehaviour
{
    SequenceEnemyManager SEman;
    SequenceEnemyMovement SEmove;
    public int enemyValue; //! Blue enemy is 1, Red enemy is 0

    void Start()
    {
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
    void EnemyDied()
    {
        SEman.enemiesKilled.Add(enemyValue);
        Destroy(gameObject);
    }

}

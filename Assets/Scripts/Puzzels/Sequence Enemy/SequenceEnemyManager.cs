using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEnemyManager : MonoBehaviour
{

    [Header ("EnemySequence")]
    private int a, b, c;
    private List<int> enemySequence = new List<int>();

    [Header("Enemies")]
    [SerializeField] private GameObject enemyRed;
    [SerializeField] private GameObject enemyBlue;

    [Header("Killed Enemies")]
    public List<GameObject> enemiesKilled;

    private void Start()
    {
        MakeSequence();
    }

    private void Update()
    {

    }

    public void MakeSequence()
    {
        enemySequence.Clear();

        a = Random.Range(0, 2);
        b = Random.Range(0, 2);
        c = Random.Range(0, 2);

        enemySequence.Add(a);
        enemySequence.Add(b);
        enemySequence.Add(c);

        SpawnSequenceEnemy();
    }

    public void LostSequence()
    {
        MakeSequence();
    }
    public void FinishedSequence()
    {
        MakeSequence();
    }
    private void SpawnSequenceEnemy()
    {
        for (int i = 0; i < enemySequence.Count; i++)
        {
            GameObject EnemyBlue = Instantiate(enemyBlue, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
            GameObject EnemyRed = Instantiate(enemyRed, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEnemyTutorial : MonoBehaviour
{
    public List<int> killedList = new List<int>();
    List<int> enemies = new List<int>();
  
    [SerializeField] GameObject enemyRed;
    [SerializeField] GameObject enemyGreen;

    public bool finishedSequence = false;

    private void OnEnable()
    {
        enemies.Add(1);
        enemies.Add(3);
    }

    private void Start()
    {
        GameObject EnemyRed = Instantiate(enemyRed, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        GameObject EnemyBlue = Instantiate(enemyGreen, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
    }
    private void Update()
    {
        if (killedList.Count >= 1)
        {
            if (killedList[0] == 1)
            {
                if (killedList[1] == 3)
                {
                    finishedSequence = true;
                }
            }
            else if (killedList[0] == 3)
            {
                killedList.Clear();
                GameObject EnemyRed = Instantiate(enemyRed, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
            }
        }
    }
}

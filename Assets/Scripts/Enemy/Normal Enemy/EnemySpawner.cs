using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private int enemiesPerWave;

    [SerializeField]private GameObject smollEnemy;
    [SerializeField]private GameObject bigEnemy;

    [SerializeField]private float smollEnemyInterval = 3.5f;
    [SerializeField]private float bigEnemyInterval = 10f;

    private List<GameObject> enemies = new List<GameObject>();
    public static EnemySpawner instance;

    void Awake(){
        if(instance == null) 
        instance = this;
    }
    void Start(){
        StartCoroutine(SpawnEnemy(smollEnemyInterval, smollEnemy));
        StartCoroutine(SpawnEnemy(bigEnemyInterval, bigEnemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject NewEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-6f, 6f)), Quaternion.identity);
        enemies.Add(NewEnemy);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    public void kill_All_Enemies(){
        for(int i = 0; i < enemies.Count; i++){
            Destroy(enemies[i]);
        }
    }
}

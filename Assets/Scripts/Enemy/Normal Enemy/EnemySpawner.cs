using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private int enemiesPerWave;

    [SerializeField]private GameObject rangedEnemy;
    [SerializeField]private GameObject meleeEnemy;

    [SerializeField]private float rangedEnemyInterval = 3.5f;
    [SerializeField]private float meleeEnemyInterval = 10f;

    private List<GameObject> enemies = new List<GameObject>();
    public static EnemySpawner instance;

    void Awake(){
        if(instance == null) 
        instance = this;
    }
    void Start(){
        StartCoroutine(SpawnEnemy(rangedEnemyInterval, rangedEnemy));
        StartCoroutine(SpawnEnemy(meleeEnemyInterval, meleeEnemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject NewEnemy = Instantiate(enemy, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        enemies.Add(NewEnemy);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    public void kill_All_Enemies(){
        for(int i = 0; i < enemies.Count; i++){
            Destroy(enemies[i]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SequenceEnemyManager : MonoBehaviour
{

    public int index = 0;

    [Header ("EnemySequence")]
    private int a, b, c;
    public List<int> enemySequence = new List<int>();

    [Header("Enemies")]
    [SerializeField] private GameObject enemyBlue;
    [SerializeField] private GameObject enemyGreen;
    [SerializeField] private GameObject enemyPurple;
    [SerializeField] private GameObject enemyRed;

    [Header("Killed Enemies")]
    public List<int> enemiesKilled;

    [Header("Timer")]
    private float timer;
    int playerSequenceHealth = 3;

    [SerializeField] GameObject maskObject;
    private Animator animMask;
    private void Start()
    {
        maskObject = GameObject.FindGameObjectWithTag("MaskBoss");
        animMask = maskObject.GetComponent<Animator>();
        MakeSequence();
    }
    private void Update()
    {
        Debug.Log(enemiesKilled.Count);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LostSequence();
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            index = 1;
        }
        if (enemiesKilled == enemySequence)
        {
            FinishedSequence();
        }
        else if (enemiesKilled.Count == 3 && enemiesKilled != enemySequence)
        {
            LostSequence();
        }
    }
    public void MakeSequence()
    {
        //SequenceEnemyUI.instance.sequenceText.Clear();
        foreach (GameObject BlueEnemy in GameObject.FindGameObjectsWithTag("EnemyBlue"))
        {
            Destroy(BlueEnemy);
        }
        foreach (GameObject RedEnemy in GameObject.FindGameObjectsWithTag("EnemyRed"))
        {
            Destroy(RedEnemy);
        }
        foreach (GameObject GreenEnemy in GameObject.FindGameObjectsWithTag("EnemyGreen"))
        {
            Destroy(GreenEnemy);
        }
        foreach (GameObject PurpleEnemy in GameObject.FindGameObjectsWithTag("EnemyPurple"))
        {
            Destroy(PurpleEnemy);
        }

        timer = 30f;
        enemySequence.Clear();

        a = Random.Range(0, 4);
        enemySequence.Add(a);
        
        b = Random.Range(0, 4);
        if (enemySequence.Contains(b))
        {
            b = Random.Range(0, 4);
        }
        enemySequence.Add(b);
        
        c = Random.Range(0, 4);
        if (enemySequence.Contains(c))
        {
            c = Random.Range(0, 4);
        }
        enemySequence.Add(c);

      
        SpawnSequenceEnemy();
    }

    public void LostSequence()
    {
        Debug.Log("The sequence was incorrect");
        playerSequenceHealth -= 1;
        if (SceneManager.GetActiveScene().name == "BossRoom")
        {
            switch (playerSequenceHealth)
            {
                case 3:
                    animMask.Play("Anim_mask_happy"); 
                    MakeSequence();
                    break;
                case 2:
                    animMask.Play("Anim_mask_neutral");
                    MakeSequence();
                    break;
                case 1:
                    animMask.Play("Anim_mask_angry");
                    MakeSequence();
                    break;
                case 0:
                    StartCoroutine(GameLostSequence());
                    break;
            }
        }
    }
    private IEnumerator GameLostSequence()
    {
        animMask.Play("Anim_mask_outburst");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOverScreen");
    }

    public void FinishedSequence()
    {
        Debug.Log("The sequence was done correctly");

        MakeSequence();
    }
    private void SpawnSequenceEnemy()
    {
       // for (int i = 0; i < 2; i++)
        //{
            GameObject EnemyBlue = Instantiate(enemyBlue, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
            GameObject EnemyGreen = Instantiate(enemyGreen, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
            GameObject EnemyPurple = Instantiate(enemyPurple, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
            GameObject EnemyRed = Instantiate(enemyRed, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity); 
       // }

    }
}

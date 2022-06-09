using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SequenceEnemyManager : MonoBehaviour
{

    public int index = 0;

    EnemySpawner enemySpawn;
    PlayerHealth[] playerHealths;

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

    bool sequenceCorrect = false;
    bool sequenceIncorrect = false;

    [Header("Timer")]
    private float timer;
    int playerSequenceHealth = 3;

    [SerializeField] GameObject maskObject;
    private Animator animMask;

    public int[] numbersOfColors = new int[] { 0, 1, 2, 3 };
    private void Start()
    {
        enemySpawn = FindObjectOfType<EnemySpawner>();
        maskObject = GameObject.FindGameObjectWithTag("MaskBoss");
        animMask = maskObject.GetComponent<Animator>();
        MakeSequence();
    }
    private void Update()
    {
        
        playerHealths = FindObjectsOfType<PlayerHealth>();

        if (enemySequence.Count < 3)
        {
            int j = Random.Range(0, 4);
            if (enemySequence.Contains(j))
            {
                Debug.Log("I have chosen a new number");
                j = Random.Range(0, 4);
            }
            else
            {
                enemySequence.Add(j);
            }
        }

        if (sequenceCorrect)
        {
            FinishedSequence();
        }
        if (sequenceIncorrect)
        {
            LostSequence();
        }
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

        Debug.Log("Killed enemy is: " + enemiesKilled[0]);
        Debug.Log("Killed enemy is: " + enemiesKilled[1]);
        Debug.Log("Killed enemy is: " + enemiesKilled[2]);
        Debug.Log("Killed enemy amount is: " + enemiesKilled.Count);

        if (enemiesKilled.Count == 3)
        {
            if (enemiesKilled[0] == enemySequence[0] && enemiesKilled[1] == enemySequence[1] && enemiesKilled[2] == enemySequence[2])
            {
                sequenceCorrect = true;
            }
            else
            {
                sequenceIncorrect = true;
            }
        }
   /*     if (enemiesKilled.Count == 3 && enemiesKilled == enemySequence)
        {
            sequenceCorrect = true;
        }
        else if (enemiesKilled.Count == 3 && enemiesKilled != enemySequence)
        {
            sequenceIncorrect = true;
        }
*/
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

        if (playerHealths != null)
        {
            for (int i = 0; i < playerHealths.Length; i++)
            {
                playerHealths[i].currentHealth += 50f;
            }
        }
        timer = 30f;
        enemySequence.Clear();
        enemiesKilled.Clear();
        enemySpawn.StartCoroutine(enemySpawn.SpawnWave(enemySpawn.enemiesPerWave));
        SpawnSequenceEnemy();
    }

    public void LostSequence()
    {
        sequenceIncorrect = false;
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
        sequenceCorrect = false;
        Debug.Log("The sequence was done correctly");

        MakeSequence();
    }
    private void SpawnSequenceEnemy()
    {
        GameObject EnemyBlue = Instantiate(enemyBlue, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        GameObject EnemyGreen = Instantiate(enemyGreen, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        GameObject EnemyPurple = Instantiate(enemyPurple, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity);
        GameObject EnemyRed = Instantiate(enemyRed, new Vector3(Random.Range(-20f, 20f), 7, Random.Range(-10f, 15f)), Quaternion.identity); 
    }
}

/*  if (enemiesKilled != null)
  {
      if (enemiesKilled.Count == 1 && enemiesKilled[0] == enemySequence[0])
      {
          if (enemiesKilled.Count == 2 && enemiesKilled[1] == enemySequence[1])
          {
              if (enemiesKilled.Count == 3 && enemiesKilled[2] == enemySequence[2])
              {
                  sequenceCorrect = true;
              }
              else
              {
                  sequenceIncorrect = true;
              }
          }
          else
          {
              sequenceIncorrect = true;
          }
      }
      else
      {
          sequenceIncorrect = true;
      }*/
//}

/*a = Random.Range(0, 4);
enemySequence.Add(a);

b = Random.Range(0, 4);
if (enemySequence.Contains(b))
{
    b = Random.Range(0, 4);
}
else
{
    enemySequence.Add(b);
}

c = Random.Range(0, 4);
if (enemySequence.Contains(c))
{
    c = Random.Range(0, 4);
}
else
{
    enemySequence.Add(c);
}
*/
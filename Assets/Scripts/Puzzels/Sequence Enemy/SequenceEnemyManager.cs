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
    [SerializeField] private GameObject enemyRed;
    [SerializeField] private GameObject enemyBlue;

    [Header("Killed Enemies")]
    public List<int> enemiesKilled;

    [Header("Timer")]
    private float timer = 60f;
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
    }
    public void MakeSequence()
    {
        SequenceEnemyUI.instance.sequenceText.Clear();
        foreach (GameObject BlueEnemy in GameObject.FindGameObjectsWithTag("EnemyBlue"))
        {
            Destroy(BlueEnemy);
        }
        foreach (GameObject RedEnemy in GameObject.FindGameObjectsWithTag("EnemyRed"))
        {
            Destroy(RedEnemy);
        }

        timer = 60f;
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
        Debug.Log(1);
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
        SceneManager.LoadScene("Main");
    }
    public void FinishedSequence()
    {
        Debug.Log(2);
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

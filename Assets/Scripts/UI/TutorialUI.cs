using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public int index = 0;
    [SerializeField] GameObject enemyTutorial;
    public GameObject mrBossTextArea;
    public Text textAreaText;
    public GameObject tutorialImage;
    bool coroutineRunning;

    SequenceEnemyTutorial SET;
    public GameObject tutorialSequence;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET = FindObjectOfType<SequenceEnemyTutorial>();
        }

        mrBossTextArea.SetActive(false);
        tutorialImage.SetActive(false);
        StartCoroutine(TutorialText());
    }
    private void Update()
    {
        //Debug.Log(coroutineRunning);
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            index = 1;
        }
        if (!coroutineRunning)
        {
            StartCoroutine(TutorialEnd());
        }
    }
    IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("BossRoom");
    }
    public IEnumerator TutorialText()
    {
        coroutineRunning = true;
        yield return new WaitForSeconds(2);
        mrBossTextArea.SetActive(true);
        yield return new WaitForSeconds(6);
        mrBossTextArea.SetActive(false);
        yield return new WaitForSeconds(1);
        tutorialImage.SetActive(true);
        yield return new WaitForSeconds(3);
        textAreaText.text = "Nice. You guys are so incompetent i need to \n teach you how to walk. Try walking up to \n those questionable cardboard cutouts over \n there and try to shoot those targets with the \n triggers.";
        mrBossTextArea.SetActive(true);
        tutorialImage.SetActive(false);
        yield return new WaitForSeconds(6);
        mrBossTextArea.SetActive(false);
        yield return new WaitForSeconds(6);
        
        enemyTutorial.SetActive(true);
        tutorialSequence.SetActive(true);

        yield return new WaitForSeconds(6);
        textAreaText.text = "Hm, that doesn't seem to do a lot. Maybe try \n hitting eacg target at the exact same time. \n Try counting down or something. If you even \n know how to count.";
        mrBossTextArea.SetActive(true);
        yield return new WaitForSeconds(6);
        textAreaText.text = "Count down together and count on each \n other. Boss out.";
        yield return new WaitForSeconds(3);
        mrBossTextArea.SetActive(false);
        coroutineRunning = false;
    }

}

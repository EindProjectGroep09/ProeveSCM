using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    public int index = 0;
    [SerializeField] GameObject enemyTutorial;
    public GameObject mrBossTextArea;
    public TMP_Text textAreaText;
    public GameObject tutorialImage;
    bool coroutineRunning = true;

    SequenceEnemyTutorial SET;
    public GameObject tutorialSequence;
    public GameObject doorTrigger;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SET = FindObjectOfType<SequenceEnemyTutorial>();
        }

        mrBossTextArea.SetActive(false);
        tutorialImage.SetActive(false);
    }
    private void Update()
    {
        Debug.Log("Textindex is: " + textIndex);
        //Debug.Log(coroutineRunning);
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            index = 1;
        }
        if (!coroutineRunning)
        {
            doorTrigger.SetActive(true);
        }
        if (!tutorialTextRunning)
        {
            StartCoroutine(TutorialText());
        }
    }

    public void SkipTutorial()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("BossRoom");
    }

    public string[] textForTutorial;
    int textIndex = 0;
    bool tutorialTextRunning = false;

    public IEnumerator TutorialText()
    {
        tutorialTextRunning = true;
        switch (textIndex)
        {
            case 2:
                tutorialImage.SetActive(true);
                break;
            case 3:
                tutorialImage.SetActive(false);
                enemyTutorial.SetActive(true);
                break;
            case 10:
                coroutineRunning = false;
                break;
        }
        if (textIndex <= textForTutorial.Length)textAreaText.text = textForTutorial[textIndex];
        mrBossTextArea.SetActive(true);
        yield return new WaitForSeconds(8f);
        mrBossTextArea.SetActive(false);
        yield return new WaitForSeconds(5);
        tutorialTextRunning = false;
        textIndex++;
    }

}
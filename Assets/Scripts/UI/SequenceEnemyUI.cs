using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SequenceEnemyUI : MonoBehaviour
{
    public static SequenceEnemyUI instance;

    public GameObject textCloud; //mask Image for sequence

    public Image[] colorImages;
    public Sprite[] sequenceColors;
    private SequenceEnemyManager SEManager;
    /*TODO 
     * 4 positions for 4 colored images
     * Set the correct image on correct position
     */
    int levelTimerInSeconds = 5;
    int levelTimerInMinutes = 0;
    public Text timerText;
    bool timerCheck = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SEManager = FindObjectOfType<SequenceEnemyManager>();
    }

    private void Update()
    {
        for (int i = 0; i < SEManager.enemySequence.Count; i++)
        {
            colorImages[i].sprite = sequenceColors[SEManager.enemySequence[i]];
        }
        if (!timerCheck)
        {
            StartCoroutine(TimerTake());   
        }
        if (levelTimerInSeconds <= 9)
        {
            timerText.text = levelTimerInMinutes + ":0" + levelTimerInSeconds;
        }
        else
        {
            timerText.text = levelTimerInMinutes + ":" + levelTimerInSeconds;
        }
    }

    private IEnumerator TimerTake()
    {
        timerCheck = true;
        yield return new WaitForSeconds(1);
        levelTimerInSeconds -= 1;
        if (levelTimerInSeconds <= 0)
        {
            levelTimerInMinutes -= 1;

            if (levelTimerInSeconds <= 0 && levelTimerInMinutes <= 0)
            {
                SceneManager.LoadScene("WinScreen");
            }
           
            levelTimerInSeconds = 59;
        }

        timerCheck = false;
    }
}

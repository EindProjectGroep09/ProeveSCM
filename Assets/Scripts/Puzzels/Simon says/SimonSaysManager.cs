using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimonSaysManager : MonoBehaviour
{

    //public GameObject[] buttons = new GameObject[3];
    public Material[] buttonColors;

    public MeshRenderer[] buttonPressed;

    private int colorPicker;

    public float stayLit;
    private float stayLitCounter;

    public Material[] oldColor = new Material[4];

    public float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    public int inputInSequence;

    private float simonSaysTimer;
    private float gameTimer;
    private int simonSaysHealth = 3;

   [SerializeField] GameObject maskObject;
    private AudioController audioController;
    private Animator animMask;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Test_Scene Boss Room")
        {
            maskObject = GameObject.FindGameObjectWithTag("MaskBoss");
            animMask = maskObject.GetComponent<Animator>();
        }

        audioController = GameObject.FindObjectOfType<AudioController>();
        StartGame();
    }
    private void Update()
    {

        simonSaysTimer -= Time.deltaTime;
        gameTimer += Time.deltaTime;

        if (simonSaysTimer < 0)
        {
            StartCoroutine(LosSequence());

            gameTimer -= 30f;
            StartGame();
        }

        if (shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;
            if (stayLitCounter < 0)
            {

                buttonPressed[activeSequence[positionInSequence]].material = oldColor[activeSequence[positionInSequence]];

                shouldBeLit = false;

                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                
                positionInSequence++;
            }
        }

        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else
            {
                if (waitBetweenCounter < 0)
                {

                    buttonPressed[activeSequence[positionInSequence]].material = buttonColors[activeSequence[positionInSequence]];

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }

        }
    }

    public void StartGame()
    {
        simonSaysTimer = 15f;

        activeSequence.Clear();

        positionInSequence = 0;
        
        inputInSequence = 0;

        colorPicker = Random.Range(0, buttonColors.Length);

        activeSequence.Add(colorPicker);

        buttonPressed[activeSequence[positionInSequence]].material = buttonColors[activeSequence[positionInSequence]];

        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ColorPressed(int pressedButton)
    {

        if (gameActive)
        {

            if (activeSequence[inputInSequence] == pressedButton)
            {

                inputInSequence++;
                if (inputInSequence >= activeSequence.Count)
                {
                    positionInSequence = 0;
                    inputInSequence = 0;

                    if (activeSequence.Count < 5)
                    {
                        colorPicker = Random.Range(0, buttonColors.Length);

                        activeSequence.Add(colorPicker);
                    }
                    else if (activeSequence.Count > 5)
                    {
                        //TODO Won sequence state
                        //gameTimer += 50f;
                        //StartGame();
                    }
                    buttonPressed[activeSequence[positionInSequence]].material = buttonColors[activeSequence[positionInSequence]];

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false; 
                    simonSaysTimer = 15f;
                }
            }
            else
            {
               audioController.gameSounds[4].Play(); 

                StartCoroutine(LosSequence());
                gameActive = false;
                //TODO Make a lose state        
                //audioController.gameSounds[4].Play();
                 

            }
        }
    }

    private IEnumerator LosSequence()
    {
        audioController.gameSounds[13].Play();

        gameTimer += 30f;
        simonSaysHealth -= 1;
        if (SceneManager.GetActiveScene().name == "Test_Scene Boss Room")
        {
            switch (simonSaysHealth)
            {
                case 3:
                    animMask.Play("Anim_mask_happy");
                    EnemySpawner.instance.SpawnWave(3);
                    break;
                case 2:
                    animMask.Play("Anim_mask_neutral");
                    EnemySpawner.instance.SpawnWave(5);
                    break;
                case 1:
                    animMask.Play("Anim_mask_angry");
                    EnemySpawner.instance.SpawnWave(8);
                    break;
                case 0:
                    StartCoroutine(GameLostSequence());
                    break;
            }
        }
        yield return new WaitForSeconds(2f);
        StartGame(); 
    }

    private IEnumerator GameLostSequence()
    {
        animMask.Play("Anim_mask_outburst");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), simonSaysTimer.ToString());
    }
}

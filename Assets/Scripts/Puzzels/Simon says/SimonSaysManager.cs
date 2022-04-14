using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    AudioController audioController;

    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();
        StartGame();
    }
    private void Update()
    {
        switch (simonSaysHealth)
        {
            //!int x;
            case 3:
                //TODO Mask Unhappy for a bit and spawn a lot of enemies
                //! Instantiate enemy * x;
                //!Play animation
                //! Timer goes down
                break;
            case 2:
                //TODO Mask stays unhappy and spawn more enemies
                break;
            case 1:
                //TODO Mask mad and spawn even more enemies and/or a boss
                break;
        }
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

                StartGame(); //! delay this
                gameActive = false;
                //TODO Make a lose state        
                //audioController.gameSounds[4].Play();
                StartCoroutine(LosSequence());
                 

            }
        }
    }

    private IEnumerator LosSequence()
    {
        audioController.gameSounds[13].Play();

        gameTimer += 30f;
        yield return new WaitForSeconds(2f);
        StartGame();
        simonSaysHealth -= 1;
    }


    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), simonSaysTimer.ToString());
    }
}

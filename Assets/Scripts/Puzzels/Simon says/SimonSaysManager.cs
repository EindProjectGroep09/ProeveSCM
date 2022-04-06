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

    private float simonSaysTimer = 15f;
    private float gameTimer = 300f;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        simonSaysTimer -= Time.deltaTime;

        if (simonSaysTimer < 0)
        {
            gameTimer += 30f;
            StartGame();
        }

        if (gameTimer < 0)
        {
            //Won game thing
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

                    colorPicker = Random.Range(0, buttonColors.Length);

                    activeSequence.Add(colorPicker);

                    buttonPressed[activeSequence[positionInSequence]].material = buttonColors[activeSequence[positionInSequence]];

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false; 
                    simonSaysTimer = 15f;
                }
            }
            else
            {
                //Game lost sequence stuff
                StartGame();
                gameActive = false;
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), simonSaysTimer.ToString());
    }
}

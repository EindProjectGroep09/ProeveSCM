using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysManager : MonoBehaviour
{

    //public GameObject[] buttons = new GameObject[3];
    public Material[] buttonColors;

    private int colorPicker;

    public float stayLit;
    private float stayLitCounter;

    public Material oldColor;

    public float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;
            if (stayLitCounter < 0)
            {
                buttonColors[activeSequence[positionInSequence]].color = oldColor.color;
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
            }
            else
            {
                if (waitBetweenCounter < 0)
                {
                    oldColor.color = buttonColors[activeSequence[positionInSequence]].color;

                    buttonColors[activeSequence[positionInSequence]].color = new Color(1f, 1f, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }

        }
    }

    public void StartGame()
    {
        positionInSequence = 0;

        colorPicker = Random.Range(0, buttonColors.Length);

        activeSequence.Add(colorPicker);

        oldColor.color = buttonColors[activeSequence[positionInSequence]].color;

        buttonColors[activeSequence[positionInSequence]].color = new Color(1f, 1f, 1f);

        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ColorPressed(int pressedButton)
    {
        if (colorPicker == pressedButton)
        {
            Debug.Log("Atta boy");
        }
        else
        {
            Debug.Log("You dumb");
        }
    }
}

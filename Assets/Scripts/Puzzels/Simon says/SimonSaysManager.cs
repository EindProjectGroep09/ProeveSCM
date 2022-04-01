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
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (stayLitCounter > 0)
        {
            stayLitCounter -= Time.deltaTime;
        }
        else
        {
            buttonColors[colorPicker].color = oldColor.color;
        }
    }

    public void StartGame()
    {
        colorPicker = Random.Range(0, buttonColors.Length);

        oldColor.color = buttonColors[colorPicker].color;

        buttonColors[colorPicker].color = new Color(1f, 1f, 1f);

        stayLitCounter = stayLit;
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

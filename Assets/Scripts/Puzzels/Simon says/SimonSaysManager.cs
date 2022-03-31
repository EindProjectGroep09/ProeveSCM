using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysManager : MonoBehaviour
{

    //public GameObject[] buttons = new GameObject[3];
    public MeshRenderer[] buttonColors;

    private int colorPicker;

    public float stayLit;
    private float stayLitCounter;

    public Material oldColor;

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
            buttonColors[colorPicker].material.color = oldColor.color;
        }
    }

    public void StartGame()
    {
        colorPicker = Random.Range(0, buttonColors.Length);

        oldColor.color = buttonColors[colorPicker].material.color;

        buttonColors[colorPicker].material.color = new Color(0f, 0f, 0f);

        stayLitCounter = stayLit;
    }
}

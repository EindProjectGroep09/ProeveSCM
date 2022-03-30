using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    [Space(10)]
    [Header("Simon Says")]
    [SerializeField] private float timer = 30f;
    [SerializeField] private List<string> simonSaysColors = new List<string> { "Red", "Green", "Blue", "Yellow" };
    [SerializeField] private GameObject[] pressurePlates = new GameObject[4];
    
    [Space(25)]
    [Header("Game Controller")]
    [SerializeField] private float gameTimer = 300f;
    [SerializeField] private int health = 3;

}

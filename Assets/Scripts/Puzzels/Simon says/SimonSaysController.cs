using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimonSaysController : MonoBehaviour
{
/*
    public List<int> inputListSimonSays;

    private List<int> simonSaysInts = new List<int>();
    private protected int randomAmount = 5;
    private int randomNumber;

    SimonSaysInputHandler SSI;

    private void Start()
    {
        SSI = GameObject.FindObjectOfType<SimonSaysInputHandler>();

    }

    private void Update()
    {
        bool areTheSame2;
        if (inputListSimonSays.Count == simonSaysInts.Count)
        {
            areTheSame2 = simonSaysInts.SequenceEqual(inputListSimonSays);
            Debug.Log(areTheSame2);
        }
    }

    private IEnumerator SimonSaysSetup()
    {
        for (int i = 0; i < randomAmount; i++)
        {
            randomNumber = Random.Range(1, 5);
            if (randomNumber == SSI.inputNumber)
            {
                Renderer GO = SSI.gameObject.GetComponent<Renderer>();
                GO.material.SetColor("_Color", Color.red);
            }
            simonSaysInts.Add(randomNumber);
        }
        return null;
    }*/
}

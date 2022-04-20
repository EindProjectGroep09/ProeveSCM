using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysInputHandler : MonoBehaviour
{

    public int numberOfButton;
    AudioController audioController;
    SimonSaysManager SSM;
    private void Start()
    {

        audioController = FindObjectOfType <AudioController>();
        SSM = FindObjectOfType <SimonSaysManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audioController.gameSounds[9].Play();
            //SSM.buttonPressed[SSM.activeSequence[SSM.inputInSequence]].material = SSM.buttonColors[SSM.activeSequence[SSM.inputInSequence]];
            SSM.buttonPressed[numberOfButton].material = SSM.buttonColors[numberOfButton];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // SSM.buttonPressed[SSM.activeSequence[SSM.inputInSequence]].material = SSM.oldColor[SSM.activeSequence[SSM.inputInSequence]];
            SSM.buttonPressed[numberOfButton].material = SSM.oldColor[numberOfButton];

            SSM.ColorPressed(numberOfButton);
        }
    }
}

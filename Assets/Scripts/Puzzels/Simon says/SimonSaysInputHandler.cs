using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysInputHandler : MonoBehaviour
{

    public int numberOfButton;

    SimonSaysManager SSM;
    private void Start()
    {
        SSM = FindObjectOfType <SimonSaysManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SSM.buttonPressed[SSM.activeSequence[SSM.inputInSequence]].material.color = SSM.buttonColors[SSM.activeSequence[SSM.inputInSequence]].color;
    }

    private void OnTriggerExit(Collider other)
    {
        SSM.buttonPressed[SSM.activeSequence[SSM.inputInSequence]].material.color = SSM.oldColor[SSM.activeSequence[SSM.inputInSequence]].color;
        SSM.ColorPressed(numberOfButton);
    }
}

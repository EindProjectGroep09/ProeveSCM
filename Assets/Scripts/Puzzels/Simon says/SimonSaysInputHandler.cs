using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysInputHandler : MonoBehaviour
{

    [SerializeField] private MeshRenderer theMaterial;
    [SerializeField] private Material oldColor;

    private void Start()
    {
        theMaterial = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        oldColor.color = theMaterial.material.color;
        theMaterial.material.color = new Color(0f, 0f, 0f);
    }

    private void OnTriggerExit(Collider other)
    {
        theMaterial.material.color = oldColor.color;
    }
}


/*SimonSaysController SSC;
public int inputNumber;

private void Start()
{
    SSC = GameObject.FindObjectOfType<SimonSaysController>();
}

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        SSC.inputListSimonSays.Add(inputNumber);
    }
}*/
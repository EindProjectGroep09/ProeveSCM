using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEditor;
using System.Threading.Tasks;

public class SequenceStateManager : MonoBehaviour{

    //these vars are for the state machine 
    [Header("State Machine Vars")]
    public SequenceBaseState currentState;

    private void Start(){

    }
}
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEditor;
using System.Threading.Tasks;

public class SequenceStateManager : MonoBehaviour{

    //! these vars are for changing the states
    [Header("Enemy Settings")] 
    private List<Collider> allTargetsInRange = new List<Collider>();
    public NavMeshAgent agent;
    public float sightRange, walkPointRange;
    public bool gotHit;
    public float runAwayTime;
    public LayerMask whatIsGround, whatIsplayer;

    //! these vars are for the state machine 
    [Header("State Machine Vars")]
    public SequenceBaseState currentState;
    [HideInInspector] public SequenceWanderState wanderState = new SequenceWanderState();
    [HideInInspector] public SequenceRunState runState = new SequenceRunState();

    private void Start(){
        currentState = wanderState;
        currentState.EnterState(this);
    }

    public void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(SequenceBaseState state){
        currentState = state;
        state.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision){
        currentState.CollisionEnter(this, collision);
    }
}
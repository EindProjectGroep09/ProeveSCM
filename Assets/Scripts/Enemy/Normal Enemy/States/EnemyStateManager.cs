using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;


public class EnemyStateManager : MonoBehaviour{

    //these vars are for changing the states 
    public bool isRanged;  //! this is code to make the bool random{ get { return (Random.value > 0.5f); } } 
    [Header("Enemy Settings")]
    public Transform player;
    public NavMeshAgent agent;
    public float sightRange, rangedRange, meleeRange, walkPointRange;
    public bool playerInRangedRange, playerInMeleeRange, playerInSightRange;
    public float timeBetweenAttacks;
    public LayerMask whatIsGround, whatIsPlayer;

    //these vars are for the state machine
    [Header("State Settings")]
    public EnemyBaseState currentState;
    [HideInInspector] public EnemyWanderState wanderState =  new EnemyWanderState();
    [HideInInspector] public EnemyChaseState chaseState = new EnemyChaseState();
    [HideInInspector] public EnemyMeleeState meleeState = new EnemyMeleeState();
    [HideInInspector] public EnemyRangedState rangedState = new EnemyRangedState(); 

    
    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

  
    }

    private void Start(){
        currentState = wanderState;
        currentState.EnterState(this);     
    }

    public void OnCollisionEnter(Collision collision){
        currentState.CollisionEnter(this, collision);
    }

    public void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        if(isRanged) Gizmos.DrawWireSphere(transform.position, rangedRange);
        if(!isRanged) Gizmos.DrawWireSphere(transform.position, meleeRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }

}

using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour{

    //these vars are for changing the states 
    public bool isRanged { get { return (Random.value > 0.5f); } } 
    
    public Transform player;
    public NavMeshAgent agent;
    public float sightRange, rangedRange, meleeRange;
    public bool playerInRangedRange, playerInMeleeRange, playerInSightRange;

    //these vars are for the state machine
    EnemyBaseState currentState;

    public EnemyWanderState wanderState = new EnemyWanderState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyMeleeState meleeState = new EnemyMeleeState();
    public EnemyRangedState rangedState = new EnemyRangedState();
    
    private void Awake(){
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = wanderState;
        wanderState.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision){
        currentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }

}

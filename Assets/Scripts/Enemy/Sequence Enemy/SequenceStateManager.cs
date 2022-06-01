using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEditor;
using System.Threading.Tasks;

public class SequenceStateManager : MonoBehaviour
{

    //! these vars are for changing the states
    [Header("Enemy Settings")]
    private List<Collider> allTargetsInRange = new List<Collider>();
    public NavMeshAgent agent;
    public float sightRange, walkPointRange, runPointRange;
    public bool gotHit;
    public float runAwayTime, waitTillRunTime, waitAtPointTime;
    public LayerMask whatIsGround, whatIsplayer;
    public List<Collision> HitObjectsList = new List<Collision>();
    public Vector3 walkPoint;
    //! these vars are for the state machine 
    [Header("State Machine Vars")]
    public SequenceBaseState currentState;
    [HideInInspector] public SequenceWanderState wanderState = new SequenceWanderState();
    [HideInInspector] public SequenceRunState runState = new SequenceRunState();

    private void Start()
    {
        currentState = wanderState;
        currentState.EnterState(this);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(SequenceBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        currentState.CollisionEnter(this, collision);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(walkPoint, 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }

    public async Task LongRunningOperationAsync(int delay){
        await Task.Delay(delay);
    }
}
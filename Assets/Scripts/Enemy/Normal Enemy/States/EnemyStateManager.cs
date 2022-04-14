using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEditor;

public class EnemyStateManager : MonoBehaviour{

    //these vars are for changing the states 
    public bool isRanged;  //! this is code to make the bool random{ get { return (Random.value > 0.5f); } } 
    [Header("Enemy Settings")]
    public List<Collider> AllTargetsInRange;
    public Transform currentTarget; 
    public NavMeshAgent agent;

    public GameObject BulletPrefab;
    
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
        AllTargetsInRange.AddRange(Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer));

        currentTarget = SearchForClostestPlayer(AllTargetsInRange);

        Debug.Log("current target: " + currentTarget);
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

    private Transform SearchForClostestPlayer(List<Collider> targets){
        float closestDistance = sightRange;
        GameObject closestTarget = null;
        foreach(Collider target in targets){
            float distance = Vector3.Distance(transform.position, target.gameObject.transform.position);

            if(closestDistance > distance){
                closestDistance = distance;
                closestTarget = target.gameObject;
            }
        }
        return closestTarget.transform;
    }

    public void DestroyGameObject(GameObject obj){
        Destroy(obj, 3);
    }

}


// [CustomEditor(typeof(EnemyStateManager))]
//  public class EnemyStateManagerEditor : Editor
//  {
//    void OnInspectorGUI()
//    {
//      var EnemyStateManager = target as EnemyStateManager;
 
//      EnemyStateManager.isRanged = GUILayout.Toggle(EnemyStateManager.isRanged, "isRanged");
     
//      if(EnemyStateManager.isRanged)
//        EnemyStateManager.BulletPrefab = EditorGUILayout.ObjectField(EnemyStateManager.BulletPrefab,  typeof(Object) );
//    }
//  }
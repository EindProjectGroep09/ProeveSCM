using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEditor;

public class EnemyStateManager : MonoBehaviour{

    //these vars are for changing the states 
    public bool isRanged;  //! this is code to make the bool random{ get { return (Random.value > 0.5f); } } 
    [Header("Enemy Settings")]
    private List<Collider> AllTargetsInRange = new List<Collider>();
    [HideInInspector] public Transform currentTarget; 
    public NavMeshAgent agent;
    public GameObject BulletPrefab;
    public float sightRange, rangedRange, meleeRange, walkPointRange;
    [HideInInspector] public bool playerInRangedRange, playerInMeleeRange, playerInSightRange;
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
        
        if(AllTargetsInRange != null)
        currentTarget = SearchForClostestPlayer(AllTargetsInRange);
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

//     #region Editor
// #if UNITY_EDITOR
//     [CustomEditor(typeof(EnemyStateManager))]
//     public class EnemyStateManagerEditor : Editor{
//         public override void OnInspectorGUI(){
//             base.OnInspectorGUI();
//             EnemyStateManager EnemyStateManager = (EnemyStateManager)target;
//             GUILayoutOption[] Options = {GUILayout.MaxWidth(180f), GUILayout.MinWidth(180f)};
            
//             EditorGUILayout.BeginHorizontal();
//             GUILayout.Label("Current Target");
//             EnemyStateManager.currentTarget = (Transform)EditorGUILayout.ObjectField(EnemyStateManager.currentTarget,  typeof(Transform), Options);
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.BeginHorizontal();
//             GUILayout.Label("Agent");
//             EnemyStateManager.agent = (NavMeshAgent)EditorGUILayout.ObjectField(EnemyStateManager.agent,  typeof(NavMeshAgent), Options);
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.BeginHorizontal();
//             GUILayout.Label("Walk Point Range");
//             EnemyStateManager.walkPointRange = EditorGUILayout.FloatField(EnemyStateManager.walkPointRange, Options);
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.BeginHorizontal();
//             GUILayout.Label("Time Between Attacks");
//             EnemyStateManager.timeBetweenAttacks = EditorGUILayout.FloatField(EnemyStateManager.timeBetweenAttacks, Options);
//             EditorGUILayout.EndHorizontal();

//             if(EnemyStateManager.isRanged){
//                 EditorGUILayout.BeginHorizontal();
//                 GUILayout.Label("Bullet Prefab");
//                 EnemyStateManager.BulletPrefab = (GameObject)EditorGUILayout.ObjectField(EnemyStateManager.BulletPrefab,  typeof(GameObject), Options);
//                 EditorGUILayout.EndHorizontal();

//                 EditorGUILayout.BeginHorizontal();
//                 GUILayout.Label("Ranged Range");
//                 EnemyStateManager.rangedRange = EditorGUILayout.FloatField(EnemyStateManager.rangedRange, Options);
//                 EditorGUILayout.EndHorizontal();
//             }else{
//                 EditorGUILayout.BeginHorizontal();
//                 GUILayout.Label("Melee Range");
//                 EnemyStateManager.meleeRange = EditorGUILayout.FloatField(EnemyStateManager.meleeRange, Options);
//                 EditorGUILayout.EndHorizontal();
//             }

//         }
//     }
// #endif
//     #endregion
}
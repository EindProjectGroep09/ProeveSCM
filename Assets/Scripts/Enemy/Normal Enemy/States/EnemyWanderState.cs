using UnityEngine;

public class EnemyWanderState : EnemyBaseState {

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public LayerMask whatIsGround, whatIsPlayer;  

    private Transform transform;  

    public override void EnterState(EnemyStateManager enemy){
        //Debug.Log("Entered Wander state");
        walkPointRange = enemy.walkPointRange;
        whatIsGround = enemy.whatIsGround;
        whatIsPlayer = enemy.whatIsPlayer;
        transform = enemy.transform;
        enemy.currentTarget = null;
    }

    public override void UpdateState(EnemyStateManager enemy){
        //* check if the player is in sightRange and switching to chasing if the player is in range 
        if(enemy.playerInSightRange = Physics.CheckSphere(transform.position, enemy.sightRange, whatIsPlayer)) enemy.SwitchState(enemy.chaseState);

        //* checking if the enemy has an wander point 
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) enemy.agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = enemy.transform.position - walkPoint;

        if(distanceToWalkpoint.magnitude < 1) walkPointSet = false;
        
    }

    public override void CollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    public void SearchWalkPoint(){
        float RandomX = Random.Range(-walkPointRange, walkPointRange);
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;

    }


}

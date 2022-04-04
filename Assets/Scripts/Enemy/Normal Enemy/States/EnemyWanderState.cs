using UnityEngine;
using UnityEngine.AI;

public class EnemyWanderState : EnemyBaseState {

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;

    private NavMeshAgent agent;

    public override void EnterState(EnemyStateManager enemy){
        
    }

    public override void UpdateState(EnemyStateManager enemy){
        //check if the player is in sightRange and switching to chasing if the player is in range 
        if(playerInSightRange = Physics.CheckSphere(transform.position, sightRange))
        enemy.SwitchState(enemy.chaseState);

        //checking if the enemy has an wander point 
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) agent.SetDestination(walkPoint);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    public void SearchWalkPoint(){
        float RandomX = Random.Range(-walkPointRange, walkPointRange);
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f)) walkPointSet = true;
    }

}

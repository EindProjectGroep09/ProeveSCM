using UnityEngine;

public class SequenceWanderState : SequenceBaseState {

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround, whatIsPlayer;
    private Transform transform;
    public override void EnterState(SequenceStateManager enemy){
        walkPointRange = enemy.walkPointRange;
        whatIsGround = enemy.whatIsGround;
        transform = enemy.transform;
    }

    public override void UpdateState(SequenceStateManager enemy){
        //* checking if the enemy has an wander point
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) enemy.agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = enemy.transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1) walkPointSet = false;
    }

    public override void CollisionEnter(SequenceStateManager enemy, Collision collision){

    }

    public void SearchWalkPoint(){
        float RandomX = Random.Range(-walkPointRange, walkPointRange);
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }
}
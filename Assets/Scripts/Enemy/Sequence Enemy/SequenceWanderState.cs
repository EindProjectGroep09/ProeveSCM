using UnityEngine;

public class SequenceWanderState : SequenceBaseState
{
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround, whatIsPlayer;
    private Transform transform;
    private bool player1Hit, player2Hit;
    private float waitTillRunTime;
    public override void EnterState(SequenceStateManager enemy)
    {
        walkPointRange = enemy.walkPointRange;
        whatIsGround = enemy.whatIsGround;
        waitTillRunTime = enemy.waitTillRunTime;
    }

    public override void UpdateState(SequenceStateManager enemy)
    {
        transform = enemy.transform;
        //* checking if the enemy has an wander point
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) enemy.agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = enemy.transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1) walkPointSet = false;

        if (enemy.HitObjectsList.Count > 2)
        {
            for (int i = 0; i < enemy.HitObjectsList.Count; i++)
            {
                if (enemy.HitObjectsList[i].gameObject.tag == "BulletP1") player1Hit = true;
                if (enemy.HitObjectsList[i].gameObject.tag == "BulletP2") player2Hit = true;

            }

            if (player1Hit && player2Hit) enemy.gameObject.GetComponent<SequenceEnemyHealth>().EnemyDied();
        }
        else if (enemy.HitObjectsList.Count > 1 && (!player1Hit || !player2Hit))
        {
            waitTillRunTime = -1 * Time.deltaTime;
        }

        if (waitTillRunTime <= 0) enemy.SwitchState(enemy.runState);

    }

    public override void CollisionEnter(SequenceStateManager enemy, Collision collision)
    {
        enemy.HitObjectsList.Add(collision);
    }

    public void SearchWalkPoint()
    {
        float RandomX = Random.Range(-walkPointRange, walkPointRange);
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    
}
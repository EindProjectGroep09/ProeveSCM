using UnityEngine;

public class SequenceRunState : SequenceBaseState
{

    public Vector3 runPoint;
    public bool runPointSet;
    public float runPointRange;
    public LayerMask whatIsGround, whatIsPlayer;
    private Transform transform;
    private float runTime;
    public override void EnterState(SequenceStateManager enemy)
    {
        runPointRange = enemy.runPointRange;
        whatIsGround = enemy.whatIsGround;
        enemy.HitObjectsList.Clear();
        runTime = enemy.runAwayTime;
    }
    public override void UpdateState(SequenceStateManager enemy)
    {

        transform = enemy.transform;
        //* makes a point to run to 
        if (!runPointSet) SearchRunPoint();
        if (runPointSet) enemy.agent.SetDestination(runPoint);

        Vector3 distanceToRunPoint = transform.position - runPoint;
        if (distanceToRunPoint.magnitude < 1) runPointSet = false;
        runTime = -1 * Time.deltaTime;

        if (runTime <= 0) enemy.SwitchState(enemy.wanderState);
    }

    public override void CollisionEnter(SequenceStateManager enemy, Collision collision)
    {

    }

    public void SearchRunPoint()
    {
        float RandomX = Random.Range(-runPointRange, runPointRange);
        float RandomZ = Random.Range(-runPointRange, runPointRange);

        runPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(runPoint, -transform.up, 2f, whatIsGround)) runPointSet = true;
    }
}
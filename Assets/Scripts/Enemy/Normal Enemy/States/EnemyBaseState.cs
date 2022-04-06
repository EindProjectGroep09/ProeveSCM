using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseState : MonoBehaviour {

    public abstract void EnterState(EnemyStateManager  enemy);

    public abstract void UpdateState(EnemyStateManager enemy);

    public abstract void OnCollisionEnter(EnemyStateManager enemy, Collision collision);

}

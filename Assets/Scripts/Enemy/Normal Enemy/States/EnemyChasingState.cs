using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState {

    public float attackRange;
    public bool playerInAttackRange;

    public override void EnterState(EnemyStateManager enemy){
    }

    public override void UpdateState(EnemyStateManager enemy){
        if(playerInAttackRange = Physics.CheckSphere(enemy.GetComponentInParent<Transform>().position, attackRange))
        enemy.SwitchState(enemy.rangedState);
    
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision){

    } 


}
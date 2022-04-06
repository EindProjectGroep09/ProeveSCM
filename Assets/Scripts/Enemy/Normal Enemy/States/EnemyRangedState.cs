using UnityEngine;

public class EnemyRangedState : EnemyBaseState {

    
    bool alreadyAttacked;
    public override void EnterState(EnemyStateManager enemy){

    }

    public override void UpdateState(EnemyStateManager enemy){

        //* stop the enemy from moving and look at the player 
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.transform.LookAt(enemy.player);

        if(!alreadyAttacked) {

            //TODO: enemy ranged attack code 

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), enemy.timeBetweenAttacks);
        }

        if(enemy.player.position.magnitude > enemy.rangedRange){
            enemy.SwitchState(enemy.chaseState);
        }

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }
}

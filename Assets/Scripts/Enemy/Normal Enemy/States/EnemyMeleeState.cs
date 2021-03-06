using UnityEngine;

public class EnemyMeleeState : EnemyBaseState {

    bool alreadyAttacked;
    public override void EnterState(EnemyStateManager enemy){
        Debug.Log("Entered Melee state");
    }

    public override void UpdateState(EnemyStateManager enemy){

        //* stop the enemy from moving and look at the player 
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.transform.LookAt(enemy.currentTarget);

        if(!alreadyAttacked) {

            //TODO: enemy melee attack code 

            alreadyAttacked = true;
            // Invoke(nameof(ResetAttack), enemy.timeBetweenAttacks);
            
        }

        if(Vector3.Distance(enemy.transform.position, enemy.currentTarget.position) > enemy.meleeRange + 3)  enemy.SwitchState(enemy.chaseState);
    
    }

    public override void CollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }
}
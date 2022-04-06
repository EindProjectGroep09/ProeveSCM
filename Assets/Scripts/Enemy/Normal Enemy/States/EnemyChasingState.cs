using UnityEngine;

public class EnemyChaseState : EnemyBaseState {

    public override void EnterState(EnemyStateManager enemy){
    }

    public override void UpdateState(EnemyStateManager enemy){
        //* chase the player 
        enemy.agent.SetDestination(enemy.player.position);

        if(enemy.isRanged) { 
            //! checks if player is in attack range and switches to ranged attack state
            if(enemy.playerInRangedRange = Physics.CheckSphere(enemy.GetComponentInParent<Transform>().position, enemy.rangedRange)){
                enemy.SwitchState(enemy.rangedState);
            }
        }else if (!enemy.isRanged) {
            //! checks if player is in attack range and switches to melee attack state
            if(enemy.playerInMeleeRange = Physics.CheckSphere(enemy.GetComponentInParent<Transform>().position, enemy.meleeRange)){
                enemy.SwitchState(enemy.meleeState);
            }
        }

        if(enemy.player.position.magnitude > enemy.sightRange){
            enemy.SwitchState(enemy.wanderState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision){

    } 


}
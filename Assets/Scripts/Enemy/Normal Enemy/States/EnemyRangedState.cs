using UnityEngine;

public class EnemyRangedState : EnemyBaseState {

    
    bool alreadyAttacked;
    public override void EnterState(EnemyStateManager enemy){
        Debug.Log("Entered ranged state");
    }

    public override void UpdateState(EnemyStateManager enemy){

        //* stop the enemy from moving and look at the player 
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.transform.LookAt(enemy.player);

        if(!alreadyAttacked) {

            //TODO: enemy ranged attack code 

            alreadyAttacked = true;
            // Invoke(nameof(ResetAttack), enemy.timeBetweenAttacks);
            
        }

        if(Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.rangedRange + 3) enemy.SwitchState(enemy.chaseState);
        

    }

    public override void CollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }

    private bool Wait(int seconds){
        float timeWaited = 0;
        
        for(int i = 0; i <= seconds; i++){
            timeWaited += Time.deltaTime;
            if(timeWaited >= seconds) return true;
        } 
        return false;
    }
}

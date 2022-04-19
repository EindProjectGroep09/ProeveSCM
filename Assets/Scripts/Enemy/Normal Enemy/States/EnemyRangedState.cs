using UnityEngine;

public class EnemyRangedState : EnemyBaseState {

    
    bool alreadyAttacked;
    public override void EnterState(EnemyStateManager enemy){
        Debug.Log("Entered ranged state");
    }

    public override void UpdateState(EnemyStateManager enemy){

        //* stop the enemy from moving and look at the player 
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.transform.LookAt(enemy.currentTarget);

        if(!alreadyAttacked) {

            //TODO: enemy ranged attack code 
            Debug.Log("i shot the serif");
            GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.bulletSpawn.position, Quaternion.Euler(enemy.bulletSpawn.position.x, enemy.bulletSpawn.position.y, enemy.bulletSpawn.position.z));
            alreadyAttacked = true;
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Impulse);
            // for(float time = 0; time < 3; time += Time.deltaTime){
            //     if(time >= 3){
            ResetAttack();
            //     }
            // }
            
        }

        if(Vector3.Distance(enemy.transform.position, enemy.currentTarget.position) > enemy.rangedRange + 3) enemy.SwitchState(enemy.chaseState);
        

    }

    public override void CollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }

    
}
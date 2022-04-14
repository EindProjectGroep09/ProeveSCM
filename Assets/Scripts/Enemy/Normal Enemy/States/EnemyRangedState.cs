using UnityEngine;
using UnityEditor;

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
            GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.transform.position, Quaternion.Euler(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z));
            enemy.DestroyGameObject(bullet);
            
            alreadyAttacked = true;

            for(float time = 0; time < 3; time += Time.deltaTime){
                if(time >= 3){
                    ResetAttack();
                }
            }
            
        }

        if(Vector3.Distance(enemy.transform.position, enemy.currentTarget.position) > enemy.rangedRange + 3) enemy.SwitchState(enemy.chaseState);
        

    }

    public override void CollisionEnter(EnemyStateManager enemy, Collision collider){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }

    
}


[CustomEditor(typeof(EnemyRangedState))]
 public class EnemyRangedStateEditor : Editor{
   void OnInspectorGUI(){
     var EnemyRangedState = target as EnemyRangedState;
 
     EnemyRangedState.flag = GUILayout.Toggle(EnemyRangedState.flag, "Flag");
     
     if(EnemyRangedState.flag)
       EnemyRangedState.i = EditorGUILayout.IntSlider("I field:", EnemyRangedState.i , 1 , 100);
 
   }
 }
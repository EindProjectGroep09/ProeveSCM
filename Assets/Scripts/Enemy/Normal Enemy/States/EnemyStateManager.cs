using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour{

    EnemyBaseState currentState;

    public EnemyWanderState wanderState = new EnemyWanderState();
    public EnemyMeleeState meleeState = new EnemyMeleeState();


    // Start is called before the first frame update
    void Start()
    {
        currentState = wanderState;
        wanderState.EnterState(this);
    }

    void OnCollisionEnter(Collision collision){
        currentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}

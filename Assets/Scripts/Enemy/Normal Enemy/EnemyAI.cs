using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    
    private Vector3 startingPosition;
    private Vector3 roamingPosition;
    
    // Start is called before the first frame update
    private void Start(){
        startingPosition = transform.position;
        roamingPosition = GetRoamingPosition();
    }



    private void Update() {

        float reachedPositionDistance = 1f;
        if(Vector3.Distance(transform.position, roamingPosition) < reachedPositionDistance){
            roamingPosition = GetRoamingPosition();
        }
    }


    private Vector3 GetRoamingPosition() { 
        return startingPosition + GetRandomDirection() * Random.Range(10f, 70f);
    }

    private Vector3 GetRandomDirection() {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void findTarget(){
        
    }
}

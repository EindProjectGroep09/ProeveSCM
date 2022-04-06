using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
   
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Partolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInRangedRange;

    private void Awake(){
        player = GameObject.Find("PlayerOne").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update(){
        //Check for sight and attack player
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInRangedRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    
        if(!playerInSightRange && !playerInRangedRange) Patroling();
        if(playerInSightRange && !playerInRangedRange) ChasePlayer();
        if(playerInSightRange && playerInSightRange) AttackPlayer();
    
    }

    private void Patroling(){
        if(!walkPointSet) SearchWalkPoint();
    }

    private void SearchWalkPoint(){
        //Calculate random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer(){

    }

    private void AttackPlayer(){

    }
}

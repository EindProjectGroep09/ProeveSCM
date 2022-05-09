using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEnemyMovement : MonoBehaviour
{

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    public float characterVelocity = 0.01f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        //transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.z + (movementPerSecond.y * Time.deltaTime));
        transform.Translate(movementPerSecond);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            calcuateNewMovementVector();
        }
    }
}

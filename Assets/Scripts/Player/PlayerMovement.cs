using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 rotateInput;
    private float speedMovement = 5.0f;
    private float speedRotate = 150.0f;

    private Animator playerAnim;
    private AudioController audioController;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        audioController = GameObject.FindObjectOfType<AudioController>();
    }
    private void Update()
    {
        playerAnim.SetFloat("MovementX", movementInput.x);
        playerAnim.SetFloat("MovementY", movementInput.y);

        transform.localPosition -= new Vector3(movementInput.x, 0, movementInput.y);
       
        transform.Rotate(new Vector3(0, rotateInput.x, 0) * (speedRotate * Time.deltaTime));

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            audioController.gameSounds[9].Play();
        }
    }

    public void OnMove(Vector2 value)
    {
        movementInput = value * speedMovement * Time.deltaTime;
     //   transform.localPosition -= new Vector3(movementInput.x, 0, movementInput.y) * (speedMovement * Time.deltaTime);
    }

    public void OnRotate(Vector2 value)
    {
        rotateInput = value * speedRotate * Time.deltaTime;
    }
}

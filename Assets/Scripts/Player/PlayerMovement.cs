using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 rotateInput;
    private float speedMovement = 5.0f;
    private float speedRotate = 100.0f;
    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * (speedMovement * Time.deltaTime));
        transform.Rotate(new Vector3(0, rotateInput.x, 0) * (speedRotate * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnRotate(InputAction.CallbackContext ctx) => rotateInput = ctx.ReadValue<Vector2>();
}

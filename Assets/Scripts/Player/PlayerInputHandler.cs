using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerInputHandler : MonoBehaviour
{

    private PlayerMovement player;
    private PlayerShoot playerS;

    [SerializeField] List<GameObject> playerPrefabs = new List<GameObject>();
    SequenceEnemyManager sem;
    TutorialUI SET;
    // Start is called before the first frame update
    void Start()
    {
        SET = FindObjectOfType<TutorialUI>();
        sem = FindObjectOfType<SequenceEnemyManager>();
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            player = GameObject.Instantiate(playerPrefabs[SET.index], transform.position, transform.rotation).GetComponent<PlayerMovement>();
        }
        else if (SceneManager.GetActiveScene().name == "BossRoom")
        {
            player = GameObject.Instantiate(playerPrefabs[sem.index], transform.position, transform.rotation).GetComponent<PlayerMovement>();
        }
            playerS = player.gameObject.GetComponent<PlayerShoot>();
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        if (player)
        {
            player.OnMove(ctx.ReadValue<Vector2>());
        }
    }
    public void RotatePlayer(InputAction.CallbackContext ctx)
    {
        if (player)
        {
            player.OnRotate(ctx.ReadValue<Vector2>());
        }
    }

    public void PlayerShoot(InputAction.CallbackContext ctx)
    {
        if (playerS && ctx.started)
        {
            playerS.Shoot();
        }
    }
}

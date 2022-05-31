using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;
    [SerializeField] private List<GameObject> characters = new List<GameObject>();
    PlayerInputManager manager;

    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = characters[index];
    }

    public void SwitchNextCharacter(PlayerInput input)
    {
        index = 1;
        manager.playerPrefab = characters[index];
    }

}

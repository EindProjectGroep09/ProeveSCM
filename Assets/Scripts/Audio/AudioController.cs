using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //public AudioSource gameMusic;
    /*!
     Every sound of the game, in this order:
    #Environment
    0. Music
    1. Random Circus Sounds
    2. Button - Press
    3. Door opening
    4. Buzzer - Sequence Fail
    #Enemy
    5. Movement
    6. Attack
    7. Damage Taken
    8. Dying
    #Player
    9. Running
    10. Damage Taken
    11. Dying
    #Gun
    12. Shoot
    #Fail Sequence
    13. Mask Laughing
     */
    public AudioSource[] gameSounds = new AudioSource[18];

    private void Start()
    {
        gameSounds[0].Play();
    }
}
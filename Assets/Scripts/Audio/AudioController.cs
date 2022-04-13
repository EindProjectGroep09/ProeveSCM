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
    3. Button Depress?
    4. Door opening
    5. Buzzer - Sequence Fail
    #Enemy
    6. Movement
    7. Attack
    8. Damage Taken
    9. Dying
    #Player
    10. Running
    11. Damage Taken
    12. Dying
    #Gun
    13. Shoot
    14. Hit (Not yet)
    #Fail Sequence
    15. Lights Out
    16.  Lights On
    17. Mask - Laughing
     */
    public AudioSource[] gameSounds = new AudioSource[18];

    private void Start()
    {
        gameSounds[0].Play();
    }
}
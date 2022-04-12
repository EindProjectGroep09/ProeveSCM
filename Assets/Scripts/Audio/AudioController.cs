using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource gameMusic;
    /*! 
     Every sound of the game, in this order:
    0. Door
    1. Button Press UI
    2. Button Press Simon Says
    3. Enemy Hit
    4. Player Hit
    5. Mask upsets
    6.  Shoot
     */
    public AudioSource[] gameSounds = new AudioSource[7];

}
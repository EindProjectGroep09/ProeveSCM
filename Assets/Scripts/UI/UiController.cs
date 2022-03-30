using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiController : MonoBehaviour
{

    AudioSource gameMusic;
    bool audioVolumeOn;

    private void Update()
    {
        if (audioVolumeOn)
        {
            gameMusic.volume = 1f;
            return; 
        }
        {
            gameMusic.volume = 0f;
            return;
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGameMain()
    {
        SceneManager.LoadScene("");
    }

    private void VolumeButton()
    {
        audioVolumeOn = !audioVolumeOn;
    }


}

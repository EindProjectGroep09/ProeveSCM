using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiController : MonoBehaviour
{
    //private AudioSource gameMusic;
    //* private bool audioVolumeOn;

    public void Update()
    {
/*        if (audioVolumeOn)
        {
            gameMusic.volume = 1f;
            return; 
        }
        {
            gameMusic.volume = 0f;
            return;
        }*/
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGameMain()
    {
        SceneManager.LoadScene("Test_Scene");
    }

/*    public void VolumeButton()
    {
        audioVolumeOn = !audioVolumeOn;
    }*/


}

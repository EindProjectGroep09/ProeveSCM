using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiController : MonoBehaviour
{
    
    
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

    }


}

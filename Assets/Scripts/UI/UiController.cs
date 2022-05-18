using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiController : MonoBehaviour
{
    //private AudioSource audio;
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource buttonClick;
    //* private bool audioVolumeOn;

    private void Start()
    {
        gameMusic.Play();
    }
    public void Update()
    {

    }


    public void QuitGame()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void StartGameMain()
    {
        buttonClick.Play();
        SceneManager.LoadScene("IntroVideo");
    }

/*    public void VolumeButton()
    {
        audioVolumeOn = !audioVolumeOn;
    }*/


}

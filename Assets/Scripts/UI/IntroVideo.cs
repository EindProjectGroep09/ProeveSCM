using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JoinTutorial());
    }
    IEnumerator JoinTutorial()
    {
        yield return new WaitForSeconds(41);
        SceneManager.LoadScene("Tutorial");
    }

    public void SkipIntroVideo()
    {
        StopCoroutine(JoinTutorial());
        SceneManager.LoadScene("Tutorial");
    }
}

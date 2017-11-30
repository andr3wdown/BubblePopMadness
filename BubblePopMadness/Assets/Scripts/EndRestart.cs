using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class EndRestart : MonoBehaviour
{
    public bool showAds = false;
    public void Restart()
    {
        if (showAds)
        {

        }
        else
        {
            DoIt();
        }
    }
    void DoIt()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator PlayAds()
    {
        yield return new WaitForEndOfFrame();
        DisplayAds();
    }

    void DisplayAds()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool Paused = false;

    public void Pause()
    {
        if (Paused)
        {
            Unpause();
        }
        else
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            Paused = true;
        }
    }
    public void Unpause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

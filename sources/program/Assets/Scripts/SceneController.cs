using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region  singleton
    public static SceneController instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    #endregion

    private int index;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas playMenuCanvas;

    public void SceneChange(int value)
    {
        ButtonSound();
        SceneManager.LoadScene(value);
    }
    public void NextScene()
    {
        ButtonSound();
        index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }
    public void PreviousScene()
    {
        ButtonSound();
        index = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        ButtonSound();
        Application.Quit();
    }

    public void PlayButton()
    {
        mainMenuCanvas.enabled = false;
        playMenuCanvas.enabled = true;
        ButtonSound();
    }    
    public void BackButton()
    {
        mainMenuCanvas.enabled = true;
        playMenuCanvas.enabled = false;
        ButtonSound();
    }
    public void ButtonSound()
    {

    }
}

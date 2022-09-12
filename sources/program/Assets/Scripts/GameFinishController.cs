using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishController : MonoBehaviour
{
    [SerializeField] private TMP_Text finishText;
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Finish(String name)
    {
        Time.timeScale = 0;
        GetComponent<Canvas>().enabled = true;
        if (name == "Player1")
        {
            finishText.text = "Player 2 Win!";
        }
        else
        {
            finishText.text = "Player 1 Win!";
        }
    }
    
}

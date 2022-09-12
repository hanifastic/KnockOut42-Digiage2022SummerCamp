using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroContoller : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _intro;
    [SerializeField] private Canvas SkipBar;
    [SerializeField] private TMP_Text SkipInfoText;
    
    double introLength;
    private float time => Time.time;
    private float skipTime = 2f;
    private Coroutine introSkip;
    private void Start()
    {
        _videoPlayer.clip = _intro;
        introLength = _intro.length + time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace))
        {
            introSkip = StartCoroutine(SkipIntro());
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Backspace))
        {
            StopCoroutine(introSkip);
            SkipInfoText.enabled = true;
            SkipBar.enabled = false;
        }
        if (time == introLength) SceneController.instance.NextScene();
    }

    IEnumerator SkipIntro()
    {
        SkipInfoText.enabled = false;
        SkipBar.enabled = true;
        yield return new WaitForSeconds(skipTime);
        SceneController.instance.NextScene();
    }

}

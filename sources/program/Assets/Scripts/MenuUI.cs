using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip buttonClick;
    private void Start()
    {
        SoundManager.Instance.PlayMusic(music);
    }

    public void ButtonClickSound()
    {
        SoundManager.Instance.Play(buttonClick);
    }
}

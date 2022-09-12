using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip MainSceneMusic;
    public static CharacterSO character1Data;
    public static CharacterSO character2Data;
    [SerializeField] private Button readybutton1;
    [SerializeField] private Button readybutton2;
    [SerializeField] private Sprite Character1;
    [SerializeField] private Sprite Character2;
    [SerializeField] private Image characterSelectedImage1;
    [SerializeField] private Image characterSelectedImage2;
    
    [SerializeField] private Button char1left;
    [SerializeField] private Button char1right;
    [SerializeField] private Button char2left;
    [SerializeField] private Button char2right;

    private void Update()
    {
        if (readybutton1.interactable == false && readybutton2.interactable == false)
        {
            if (characterSelectedImage1.sprite.name == "character1")
            {
                character1Data = (CharacterSO)Resources.Load("ScriptableObjects/Player1");
            }
            else
            {
                character1Data = (CharacterSO)Resources.Load("ScriptableObjects/Player2");
            }
            if (characterSelectedImage2.sprite.name == "character1")
            {
                character2Data = (CharacterSO)Resources.Load("ScriptableObjects/Player1");
            }
            else
            {
                character2Data = (CharacterSO)Resources.Load("ScriptableObjects/Player2");
            }
            DataController.instance.SetCharacterData(character1Data,character2Data);
            SoundManager.Instance.PlayMusic(MainSceneMusic);
            SceneController.instance.NextScene();
        }
    }

    public void ReadySelection(Button button)
    {
        button.interactable = false;

        if (button == readybutton1)
        {
            char1left.interactable = false;
            char1right.interactable = false;
        }
        else
        {
            char2left.interactable = false;
            char2right.interactable = false;
        }

        PlayButtonSound();

    }

    public void CharacterSwap(Image image)
    {
        if (image.sprite == Character1)
        {
            image.sprite = Character2;
        }
        else
        {
            image.sprite = Character1;
        }

        PlayButtonSound();
    }

    public void PlayButtonSound()
    {
        SoundManager.Instance.Play(buttonClick);

    }
}

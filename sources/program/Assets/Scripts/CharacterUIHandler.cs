using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CharacterUIHandler : Character
{
    [SerializeField] private TMP_Text characterHealth;
    [SerializeField] private Image characterSprite;

    private new void Start()
    {
        Initialization();
        SetHealth(characterData.Health);
        SetImage(characterData.sprite);
    }
    
    public void SetHealth(float value)
    {
        characterHealth.text = value.ToString();
    }    
    public void SetImage(Sprite sprt)
    {
        characterSprite.sprite = sprt;
    }
}

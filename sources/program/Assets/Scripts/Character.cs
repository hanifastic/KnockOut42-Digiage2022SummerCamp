using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character : MonoBehaviour
{
    protected CharacterSO characterData;
    protected CharacterInputController _CharacterController;
    protected Jump _jump;
    protected Animator _animator;

    public void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        if (gameObject.name == "Player1") characterData = DataController.instance.character1Data;
        else characterData = DataController.instance.character2Data;
        _CharacterController = GetComponent<CharacterInputController>();
        _jump = GetComponent<Jump>();
        _animator = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().sprite = characterData.sprite;
        _animator.runtimeAnimatorController = characterData._animatior;
        GetComponent<SpriteRenderer>().sprite = characterData.sprite;
    }

    public virtual void jump() { }
}

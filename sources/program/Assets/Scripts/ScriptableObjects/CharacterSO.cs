using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterSO : ScriptableObject
{
    public string CharacterName;
    public float Health;
    public float MovementSpeed;
    public AnimatorController _animatior;
    
    
    public Sprite sprite;
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    
    public CharacterSO character1Data;
    public CharacterSO character2Data;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetCharacterData(CharacterSO data1, CharacterSO data2)
    {
        character1Data = data1;
        character2Data = data2;
    }
}

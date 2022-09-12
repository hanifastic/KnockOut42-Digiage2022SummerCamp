using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public TMP_Text character1Health;
    [SerializeField] public TMP_Text character2Health;
    [SerializeField] public Image character1Sprite;
    [SerializeField] public Image character2Sprite;
    [SerializeField] public PauseMenu pauseUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.Pause();
        }
    }
}

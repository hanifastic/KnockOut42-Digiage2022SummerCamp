using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : Character
{
    public float HorizontalMovement = 0;
    private KeyCode right;
    private KeyCode left;
    private KeyCode jumpKey;
    private KeyCode basicAttack;
    private KeyCode HeavyAttack;

    private void Awake()
    {
        switch (gameObject.name)
        {
            case "Player1":
                right = KeyCode.D;
                left = KeyCode.A;
                jumpKey = KeyCode.W;
                basicAttack = KeyCode.C;
                HeavyAttack = KeyCode.V;
                break;
            case "Player2":
                right = KeyCode.RightArrow;
                left = KeyCode.LeftArrow;
                jumpKey = KeyCode.UpArrow;
                basicAttack = KeyCode.M;
                HeavyAttack = KeyCode.N;
                break;
        }
    }

    private void Update()
    {
        float movement = 0;
        if (Input.GetKey(right)) movement += 1;
        if (Input.GetKey(left)) movement -= 1;
        HorizontalMovement = movement;
        if (Input.GetKeyDown(jumpKey)) _jump._desiredJump = true;
        if (Input.GetKeyDown(basicAttack)) StartCoroutine(GetComponent<CharacterKnockBack>().Attack());
        if (Input.GetKeyDown(HeavyAttack));

    }
}

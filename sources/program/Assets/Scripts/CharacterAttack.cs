using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private float KnockBackValue;
    private BoxCollider2D _coll;

    private void Start()
    {
        _coll = GetComponent<BoxCollider2D>();
    }

    public IEnumerator Attack(float value)
    {
        KnockBackValue = value;
        _coll.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direction = GetComponent<SpriteRenderer>().flipX ?  new Vector2(1,0) : new Vector2(1,0);
            GetComponent<CharacterKnockBack>().GetKnockBack(KnockBackValue, direction);
        }
        
    }
}

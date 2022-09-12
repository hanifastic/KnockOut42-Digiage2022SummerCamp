using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Death : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.GetComponent<CharacterHealth>().TakeDamage();
        StartCoroutine(Respawn(other.transform));
    }

    IEnumerator Respawn(Transform character)
    {
        yield return new WaitForSeconds(1f);
        int index = UnityEngine.Random.Range(0, spawnPoints.Length);
        character.position = spawnPoints[index].position;
    }
}

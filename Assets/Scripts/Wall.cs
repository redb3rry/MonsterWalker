using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Monster monster;
    [SerializeField] private float impactTime = 2f;

    private void Start()
    {
        monster = FindObjectOfType<Monster>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == monster)
        {
            monster.SetRunFrom(transform);
        }
    }
}

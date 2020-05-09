using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    private GameLogic gameLogic;
    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Renderer coinRenderer;
    [SerializeField] private Collider2D coinCollider;
    [SerializeField] private GameLogic gameLogic;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void Update()
    {
        coinRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        coinCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            gameLogic.AddCoin();
        }
        if (collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}

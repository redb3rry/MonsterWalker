using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Renderer heartRenderer;
    [SerializeField] private Collider2D heartCollider;
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private int damage = -1;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    void Update()
    {
        heartRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        heartCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            gameLogic.UpdateLives(damage);
        }
        if (collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}

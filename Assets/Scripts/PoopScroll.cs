using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScroll : MonoBehaviour
{
    [SerializeField] private Renderer poopRenderer;
    [SerializeField] private Collider2D poopCollider;
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    void Update()
    {
        poopRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        poopCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameLogic.UpdateLives(damage);
        }
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenMeat : MonoBehaviour
{
    [SerializeField] private Renderer meatRenderer;
    [SerializeField] private Collider2D meatCollider;
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private int damage = 2;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    void Update()
    {
        meatRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        meatCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
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

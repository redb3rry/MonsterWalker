using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, Scrolling
{
    [SerializeField] public float coinSpeed;
    [SerializeField] private Renderer coinRenderer;
    [SerializeField] private Collider2D coinCollider;
    [SerializeField] private GameLogic gameLogic;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        gameLogic.scrollingObjects.Add(this);
        ApplySpeedMod();
    }

    void Update()
    {
        coinRenderer.material.mainTextureOffset += new Vector2(0f, coinSpeed * Time.deltaTime);
        coinCollider.offset -= new Vector2(0f, coinSpeed * Time.deltaTime);
    }
    public void ApplySpeedMod()
    {
        coinSpeed = coinSpeed * gameLogic.scrollingSpeedMod;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Monster")
        {
            gameLogic.AddCoin();
        }
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}

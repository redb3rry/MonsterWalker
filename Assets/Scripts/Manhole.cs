using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour, Scrolling
{
    [SerializeField] public float manholeSpeed;
    [SerializeField] private Renderer manholeRenderer;
    [SerializeField] private Collider2D manholeCollider;
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private int damage = 4;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        gameLogic.scrollingObjects.Add(this);
        ApplySpeedMod();
    }

    // Update is called once per frame
    void Update()
    {
        manholeRenderer.material.mainTextureOffset += new Vector2(0f, manholeSpeed * Time.deltaTime);
        manholeCollider.offset -= new Vector2(0f, manholeSpeed * Time.deltaTime);
    }

    public void ApplySpeedMod()
    {
        manholeSpeed = manholeSpeed * gameLogic.scrollingSpeedMod;
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

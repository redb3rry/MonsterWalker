using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private Renderer speUpRenderer;
    [SerializeField] private Collider2D speUpCollider;
    [SerializeField] private GameLogic gameLogic;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    void Update()
    {
        speUpRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        speUpCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            gameLogic.gameSpeed += 0.06f;
        }
        if (collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{
    [SerializeField] private Renderer speDowRenderer;
    [SerializeField] private Collider2D speDowCollider;
    [SerializeField] private GameLogic gameLogic;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }
    void Update()
    {
        speDowRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
        speDowCollider.offset -= new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            gameLogic.gameSpeed -= 0.06f;
        }
        if (collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}

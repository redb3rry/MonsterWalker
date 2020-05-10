using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private Renderer backgroundRenderer;
    [SerializeField] private GameLogic gameLogic;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, gameLogic.gameSpeed * Time.deltaTime);
    }
}

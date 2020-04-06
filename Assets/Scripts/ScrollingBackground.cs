using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] public float backgroundSpeed;
    [SerializeField] private Renderer backgroundRenderer;
    [SerializeField] private GameLogic gameLogic;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void Update()
    {
        backgroundSpeed = backgroundSpeed * gameLogic.scrollingSpeedMod;
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
    }
}

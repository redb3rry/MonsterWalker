using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour, Scrolling
{
    [SerializeField] public float backgroundSpeed;
    [SerializeField] private Renderer backgroundRenderer;
    [SerializeField] private GameLogic gameLogic;
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        gameLogic.scrollingObjects.Add(this);
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
    }

    public void ApplySpeedMod()
    {
        backgroundSpeed = backgroundSpeed * gameLogic.scrollingSpeedMod;
    }
}

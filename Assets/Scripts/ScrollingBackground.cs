using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] public float backgroundSpeed;
    [SerializeField] private Renderer backgroundRenderer;
    void Start()
    {
        
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
    }
}

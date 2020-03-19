using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScroll : MonoBehaviour
{
    [SerializeField] public float poopSpeed;
    [SerializeField] private Renderer poopRenderer;
    [SerializeField] private Collider2D poopCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        poopRenderer.material.mainTextureOffset += new Vector2(0f, poopSpeed * Time.deltaTime);
        poopCollider.offset -= new Vector2(0f, poopSpeed * Time.deltaTime);
    }
}

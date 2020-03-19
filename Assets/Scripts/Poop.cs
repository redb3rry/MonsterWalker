using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField] float poopSpeed = 1f;
    private Vector2 poopPosition;
    void Start()
    {
        
    }

    void Update()
    {
        poopPosition = new Vector2(transform.position.x, transform.position.y);
        poopPosition.y = poopPosition.y - poopSpeed;
        transform.position = poopPosition;
    }
}

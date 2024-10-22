﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 9f;
    [SerializeField] float playerSpeed = 0.3f;
    private float screenWidthInUnits = 8f;
    private GameLogic gameLogic;
    private Animator playerAnim;

    //state
    private Touch touch;
    private Vector2 playerPos; 
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.gameRunnning && Time.timeScale != 0f)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        touch = Input.GetTouch(0);
        playerPos = new Vector2(transform.position.x, transform.position.y);
        playerPos.x = Mathf.Clamp(Mathf.Clamp(GetPositionX(), playerPos.x - playerSpeed, playerPos.x + playerSpeed), minX, maxX);
        transform.position = playerPos;
    }
    public void StopPlayer()
    {
        playerAnim.SetBool("gameRunning", false);
    }
    private float GetPositionX()
    {
        return touch.position.x / Screen.width * screenWidthInUnits;
    }
}

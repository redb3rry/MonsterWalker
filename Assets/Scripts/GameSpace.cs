using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpace : MonoBehaviour
{
    private Player player;
    private Wall[] walls;
    [SerializeField] private bool leashOn;
    [SerializeField] private float leashLength = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        walls = FindObjectsOfType<Wall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leashOn)
        {
            ApplyLeash();
        }
    }

    private void ApplyLeash()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 rPos = new Vector2(Mathf.Clamp(playerPos.x + leashLength, 0, 9), playerPos.y); ;
        Vector2 lPos = new Vector2(Mathf.Clamp(playerPos.x - leashLength, 0, 9), playerPos.y);
        walls[0].transform.position = lPos;
        walls[1].transform.position = rPos;
    }
}

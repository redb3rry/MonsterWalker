using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //config
    [SerializeField] float monsterSpeed = 1f;
    //references
    Player player;
    //states
    Vector2 playerToMonsterVector;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigibody = GetComponent<Rigidbody2D>();
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        playerToMonsterVector = this.transform.position - player.transform.position;
        rigibody.AddForce(monsterSpeed * playerToMonsterVector);
    }
}

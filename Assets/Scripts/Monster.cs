using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //config
    [SerializeField] float monsterSpeed = 1f;
    //references
    Player player;
    Transform runFrom;
    //states
    Vector2 targetToMonsterVector;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        RunFromPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        RunAwayFrom(runFrom);
    }
    private void RunAwayFrom(Transform target)
    {
        Rigidbody2D rigibody = GetComponent<Rigidbody2D>();
        Vector2 targetPos = new Vector2(player.transform.position.x, player.transform.position.y);
        targetToMonsterVector = (this.transform.position - player.transform.position);
        rigibody.AddForce(monsterSpeed * targetToMonsterVector);
        transform.right = this.transform.position - target.transform.position;
    }
    public void SetRunFrom(Transform runFrom)
    {
        this.runFrom = runFrom;
    }
    public void RunFromPlayer()
    {
        runFrom = player.transform;
    }
}

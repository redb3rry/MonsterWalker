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
    private GameLogic gameLogic;
    private Animator monsterAnim;
    private Rigidbody2D monsterRigibody;
    //states
    Vector2 targetToMonsterVector;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameLogic = FindObjectOfType<GameLogic>();
        monsterAnim = GetComponent<Animator>();
        monsterRigibody = GetComponent<Rigidbody2D>();
        RunFromPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.gameRunnning)
        {
            RunAwayFrom(runFrom);
        }
    }
    private void RunAwayFrom(Transform target)
    {
        Rigidbody2D rigibody = GetComponent<Rigidbody2D>();
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        targetToMonsterVector = (this.transform.position - target.transform.position);
        rigibody.AddForce(monsterSpeed * targetToMonsterVector);
        transform.up = this.transform.position - target.transform.position - new Vector3(0,0);
    }
    public void SetRunFrom(Transform runFrom)
    {
        this.runFrom = runFrom;
    }
    public void RunFromPlayer()
    {
        runFrom = player.transform;
    }
    public void StopMonster()
    {
        monsterAnim.SetBool("gameRunning", false);
        monsterRigibody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}

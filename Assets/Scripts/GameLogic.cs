using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private Image image;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private int timeElapsed = 0;
    [SerializeField] TrapSpawner ts;
    public float gameSpeed = 0.175f;
    private int lives = 3;
    private float timer;
    public bool gameRunnning = true;
    private Player player;
    private Monster monster;
    private int highscore;
    private int points;
    private int coins = 0;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        monster = FindObjectOfType<Monster>();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        highscore = PlayerPrefs.GetInt("highscore",0);
        gameSpeed = 0.165f;
    }
    void Update()
    {
        if (gameRunnning)
        {
            CountTime();
        }
    }

    public void TogglePause()
    {
        if (gameRunnning)
        {
            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    private void CountTime()
    {
        timer += 1 * Time.deltaTime;
        points = Mathf.RoundToInt(timer) + 10*coins;
        gameScoreText.text = Mathf.RoundToInt(timer).ToString() +"m";
        if(timer/10 > timeElapsed)
        {
            timeElapsed++;
            ts.timeBetweenTraps = Mathf.Clamp(ts.timeBetweenTraps - 0.5f,0.01f,10f);
            gameSpeed += 0.01f;
            ts.StopSpawning();
            ts.StartSpawning();
        }
    }

    public void UpdateLives(int livesLost)
    {
        lives -= livesLost;
        image.sprite = lifeSprites[Mathf.Clamp(lives,0,3)];
        if (lives < 0)
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        gameRunnning = false;
        gameSpeed = 0f;
        ts = FindObjectOfType<TrapSpawner>();
        ts.StopSpawning();
        player.StopPlayer();
        monster.StopMonster();
        if(points > highscore)
        {
            PlayerPrefs.SetInt("highscore", points);
            highscoreText.text = "New highscore!";
        }
        else
        {
            highscoreText.text = "";
        }
        endScoreText.text = "Score\n" + points.ToString();
        PlayerPrefs.SetInt("lastScore", points);
        gameOverPanel.SetActive(true);
    }
    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private int lives = 3; //TODO unserialize
    [SerializeField] private Image image;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] public float scrollingSpeedMod = 1f;
    private float timer;
    public List<Scrolling> scrollingObjects = new List<Scrolling>();
    public bool gameRunnning = true;
    private Player player;
    private Monster monster;
    private Canvas gameCanvas;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private int timeElapsed = 0;
    [SerializeField] TrapSpawner ts;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        monster = FindObjectOfType<Monster>();
        gameCanvas = FindObjectOfType<Canvas>();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
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
        int points = Mathf.RoundToInt(timer);
        gameScoreText.text = points.ToString("n0");
        if(timer/10 > timeElapsed)
        {
            timeElapsed++;
            ts.timeBetweenTraps = Mathf.Clamp(ts.timeBetweenTraps - 0.2f,0.01f,10f);
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
        scrollingSpeedMod = 0f;
        //sceneLoader.LoadNextScene();
        ts = FindObjectOfType<TrapSpawner>();
        ts.StopSpawning();
        player.StopPlayer();
        monster.StopMonster();
        ChangeSpeed();
        endScoreText.text = "Score\n" + timer.ToString("n0");
        gameOverPanel.SetActive(true);
    }

    private void ChangeSpeed()
    {
        foreach (Scrolling obj in scrollingObjects)
        {
            obj.ApplySpeedMod();
        }
    }
}

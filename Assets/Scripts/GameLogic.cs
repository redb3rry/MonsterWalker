using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Sprite[] lifeSprites;
    [SerializeField] private int lives = 3; //TODO unserialize
    [SerializeField] private Image image;
    private float timer;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] public float scrollingSpeedMod = 1f;

    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("n2");
    }
    public void UpdateLives(int livesLost)
    {
        lives -= livesLost;
        image.sprite = lifeSprites[Mathf.Clamp(lives,0,3)];
        if (lives < 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

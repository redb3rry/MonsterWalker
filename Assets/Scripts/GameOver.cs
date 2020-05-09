using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    void Start()
    {
        endScoreText.text = "Score: " + PlayerPrefs.GetInt("lastScore",0).ToString();
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("n2");
    }
}

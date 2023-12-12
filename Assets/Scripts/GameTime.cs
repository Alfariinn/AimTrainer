using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static Action OnGameEnd;


    [SerializeField] TMP_Text timerText;

    [SerializeField] const float gameTime = 60f;
    float endTime;

    void Start()
    {
        endTime = Time.time + gameTime;
    }

    void Update()
    {
        float timeLeft = endTime - Time.time;

        if (timeLeft <= 0)
        {
            OnGameEnd?.Invoke();
            timeLeft = 0;
            enabled = false;
        }

        timerText.text = timeLeft.ToString("0.0");
    }
}
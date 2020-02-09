using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static float timer = 0f;

    private void Update()
    {
        timer = Time.timeSinceLevelLoad;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer%60);
        string minutesString = ((int) minutes / 10).ToString() + ((int) minutes % 10).ToString();
        string secondsString = ((int) seconds / 10).ToString() + ((int) seconds % 10).ToString();
        scoreText.text = minutesString + ":" + secondsString;
    }
}

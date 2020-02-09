using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class AddRank : MonoBehaviour
{
    public InputField inputField;
    public Text timeText;
    public float timer;

    public void Update()
    {
        timer = Score.timer;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer%60);
        string minutesString = ((int) minutes / 10).ToString() + ((int) minutes % 10).ToString();
        string secondsString = ((int) seconds / 10).ToString() + ((int) seconds % 10).ToString();
        timeText.text = "      TIME " + minutesString + ":" + secondsString;
    }

    public void EnterRank()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            string name = inputField.text.Trim();
            int time = (int)Score.timer;
            Tuple<string, int> newrank = new Tuple<string, int>(name, time);
            if (time > Menu.ranks[9].Item2)
            {
                Menu.ranks[9] = newrank;
                for (int i = 8; i >= 0; i--)
                {
                    if (time > Menu.ranks[i].Item2)
                    {
                        Tuple<string, int> tmp = Menu.ranks[i];
                        Menu.ranks[i] = newrank;
                        Menu.ranks[i+1] = tmp;
                    }
                    
                }
            }

            string path = "ranks.txt";
            
            StreamWriter writer = new StreamWriter(path);

            for (int i = 0; i < 10; i++)
            {
                if (Menu.ranks[i].Item2 != -1)
                {
                    
                    writer.WriteLine(Menu.ranks[i].Item1 + ' ' + Menu.ranks[i].Item2.ToString("0"));
                }
            }
            writer.Close();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

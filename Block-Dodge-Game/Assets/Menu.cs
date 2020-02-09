using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    public static Tuple<string, int>[] ranks = new Tuple<string, int>[10];

    void Start()
    {
        string path = "ranks.txt";
        StreamReader reader = new StreamReader(path); 
        string line;
        int cnt = 0;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(' ');
            ranks[cnt] = new Tuple<string, int>(parts[0], Int32.Parse(parts[1]));
            cnt++;
        }
        reader.Close();
        for (int i = cnt; i < 10; i++)
        {
            ranks[i] = new Tuple<string, int>("null", -1);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Rank()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}

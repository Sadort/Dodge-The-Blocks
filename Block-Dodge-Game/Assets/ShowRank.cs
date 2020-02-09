using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowRank : MonoBehaviour
{
    public string showRank = "";
    public Text rankText;

    private bool flag = false;
    // Start is called before the first frame update
    void Update()
    {
        if (!flag)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Menu.ranks[i].Item2 != -1)
                {
                    int minutes = Menu.ranks[i].Item2 / 60;
                    int seconds = Menu.ranks[i].Item2 % 60;
                    string minutesString = (minutes / 10).ToString() + ((int) minutes % 10).ToString();
                    string secondsString = (seconds / 10).ToString() + ((int) seconds % 10).ToString();
                    showRank += Menu.ranks[i].Item1 + '\t' + minutesString + ':' + secondsString + '\n';
                }
            }

            rankText.text = showRank;
            flag = true;
        }
        

    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
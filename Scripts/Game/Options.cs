using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public float timer = 1;

    [SerializeField]
    private Text timeText;
   public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void TimeScaleController()
    {
        timer++;
        Time.timeScale = timer;
        timeText.text = timer.ToString();

        if(timer > 3)
        {
            timer = 1f;
            Time.timeScale = timer;
            timeText.text = timer.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public float startTime = 60; // in seconds
    public bool setStart = false;
    public float time; // in seconds

    public int destruction;

    public Text text;
    public Text textbg;

    public Text text2;
    public Text textbg2;

    public GameObject gameOverPopup;

    // Start is called before the first frame update
    void Start()
    {
        if(setStart)
            time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        handleTime();
        handleDestruction();
    }

    private void handleDestruction()
    {
        text2.text = destruction.ToString("00");
        textbg2.text = text2.text;
    }

    private void handleTime()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            time = 0;
            endGameLost();
        }

        text.text = ((int)time / 60).ToString("00") + ":" + ((int)time % 60).ToString("00");
        textbg.text = text.text;
    }

    private void endGameLost()
    {
        ScoreManager.main.timeRemaining = time;
        ScoreManager.main.destruction = destruction;

        gameOverPopup.SetActive(true);
    }
}

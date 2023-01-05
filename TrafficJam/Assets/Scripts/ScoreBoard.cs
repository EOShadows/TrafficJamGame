using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public float startTime = 60; // in seconds
    private float time; // in seconds
    public Text text;
    public Text textbg;

    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            time = 0;
            endGameLost();
        }

        text.text = ((int)time / 60).ToString("00") + ":" + ((int)time % 60).ToString("00");
        textbg.text = text.text;
    }

    private void endGameLost()
    {

    }
}

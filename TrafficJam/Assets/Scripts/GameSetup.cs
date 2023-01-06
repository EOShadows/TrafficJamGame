using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public float timeGiven = 20;
    public int end = 10;
    public float difficultyRampup = 1;


    public ScoreBoard sb;

    // Start is called before the first frame update
    void Start()
    {
        sb.time = timeGiven;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

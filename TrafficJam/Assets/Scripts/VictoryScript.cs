using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    private int step = 0;
    public GameObject[] steps;

    public bool upgradeSelected = false;

    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.main.day++;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = ScoreManager.main.day.ToString();

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if(!(step == 1)){
                nextStep();
            }
        }
    }

    private void nextStep(){
        if (step == steps.Length - 1)
            SceneManager.LoadScene("GameScene");

        steps[step].SetActive(false);
        step = Mathf.Min(step + 1, steps.Length - 1);
        steps[step].SetActive(true);
    }

    public void AddSpeed(){
        // Debug.Log("Called");
        GameObject obj = GameObject.Find("pointHolder");
        obj.GetComponent<pointHolder>().speed += 50f;
        nextStep();
        // upgradeSelected = true;
    }

    public void AddWeight(){
        GameObject obj = GameObject.Find("pointHolder");
        obj.GetComponent<pointHolder>().mass *= 10f;
        nextStep();
        // upgradeSelected = true;
    }
}

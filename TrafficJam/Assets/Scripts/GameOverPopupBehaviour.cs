using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void quit()
    {
        Time.timeScale = 0;
        Application.Quit();
    }

    public void play(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointHolder : MonoBehaviour
{
    public float score;
    public float speed = 400f;
    public float mass = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scoreKeeper");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

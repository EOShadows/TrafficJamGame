using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    private enum direction
    {
        UP = 0,
        RIGHT = 1,
        LEFT = 2
    }

    private direction dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMovement();
    }

    private void updateMovement()
    {

    }
}

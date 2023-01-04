using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarningTracker : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D playerRb;

    private bool faultInAction = false;
    private bool faultInActionStatBefore = false;

    private Vector2 faultBegan;
    public float faultGrace = 15;
    public GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(faultInAction + " " + Mathf.Abs(faultBegan.y - player.position.y));

        if (!faultInAction)
            faultInAction = playerRb.velocity.y < 0;
        else if (player.position.y > faultBegan.y)
            faultInAction = false;

        if (!faultInActionStatBefore && faultInAction)
        {
            faultBegan = player.position;
        }

        if (!warning.activeSelf)
            warning.SetActive(faultInAction && Mathf.Abs(faultBegan.y - player.position.y) >= faultGrace);
        else
            warning.SetActive(faultInAction);

        faultInActionStatBefore = faultInAction;
    }
}

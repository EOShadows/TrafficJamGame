using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    GameObject player;
    public GameObject warning;
    bool warningExists = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y - 145f && warning){
            warning.SetActive(true);
        }
        if(warningExists && player.transform.position.y > transform.position.y - 30f){
            Destroy(warning);
            warningExists = false;
        }
        else if(player.transform.position.y > transform.position.y + 40f){
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(col.gameObject == player){
            col.gameObject.GetComponent<carMovement>().kill();
            // Debug.Log("oof");
        }
    }
}

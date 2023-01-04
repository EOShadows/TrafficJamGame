using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAtDistance : MonoBehaviour
{
    public Transform target;
    public float distance;

    public bool below = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(target.transform.position, transform.position));

        if ((!below || target.transform.position.y > transform.position.y) && Vector2.Distance(target.transform.position, transform.position) >= distance)
            Destroy(gameObject);
    }
}

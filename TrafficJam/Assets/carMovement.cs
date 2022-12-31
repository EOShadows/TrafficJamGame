using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    public float rotationSpeed;
    private float vertical;
    private float horizontal;
    public float driftFactor;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift)){
            body.velocity = (((transform.up + Vector3.Normalize(body.velocity)*driftFactor) / (driftFactor+1f)) * vertical) * speed * Time.fixedDeltaTime;
        }
        else{
            body.velocity = (transform.up * vertical) * speed * Time.fixedDeltaTime;

        }
        transform.Rotate((transform.forward * horizontal * -1f) * rotationSpeed * Time.fixedDeltaTime);
    }
}

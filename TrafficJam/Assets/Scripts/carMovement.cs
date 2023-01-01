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

    public float maxTurn = 0.2f;

    public BoxCollider2D range;

    private Vector2 effect = Vector2.zero;
    private float effectTime = 1;
    private float effectStarted = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");


        if(Input.GetButton("Drift")){
            body.velocity = (((transform.up * vertical + Vector3.Normalize(body.velocity)*driftFactor) / (driftFactor+1f))) * speed * Time.fixedDeltaTime;
        }
        else{
            body.velocity = (transform.up * vertical) * speed * Time.fixedDeltaTime;

        }

        /*updateEffect();
        body.velocity += effect;*/

        doRotation(horizontal);
    }

    private void updateEffect()
    {
        queryEffect();

        float lapse = Time.time - effectStarted;
        
    }

    private void queryEffect()
    {

        float bottomRange = range.transform.position.y - range.size.y / 2;
        float rightRange = range.transform.position.x + range.size.x / 2;
        float leftRange = range.transform.position.x - range.size.x / 2;

        bool condition1 = transform.position.y < bottomRange;
        bool condition2 = transform.position.x > rightRange;
        bool condition3 = transform.position.x < leftRange;

        if (condition1)
        {
            transform.position = new Vector2(transform.position.x, bottomRange);
            startEffect(Vector2.up * 2, 1);
        }
        else if (condition2)
        {
            transform.position = new Vector2(rightRange, transform.position.y);
            startEffect(Vector2.left * 2, 1);
        }
        else if (condition3)
        {
            transform.position = new Vector2(leftRange, transform.position.y);
            startEffect(Vector2.right * 2, 1);
        }
    }

    private void startEffect(Vector2 effect, float effectLasts)
    {
        effectStarted = Time.time;
        effectTime = effectLasts;
        //this.effect = effect; 
    }

    private void doRotation(float horizontal)
    {
        transform.Rotate((transform.forward * horizontal * -1f) * rotationSpeed * Time.fixedDeltaTime);

        float curRot = transform.rotation.eulerAngles.z;
        float maxTurnConverted = 360 * maxTurn;

        float x = transform.rotation.eulerAngles.x;
        float y = transform.rotation.eulerAngles.y;
        float z = Mathf.Clamp(curRot, ((curRot < 180) ? -1 : 360 - maxTurnConverted), (curRot < 180) ? maxTurnConverted : 361);

        transform.rotation = Quaternion.Euler(x, y, z);
    }
}

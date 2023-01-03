using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    public enum direction
    {
        UP = 0,
        RIGHT = 1,
        LEFT = 2
    }

    private direction dir;
    private bool directionUpToDate = false;

    public float speed = 2;
    public float rotateSpeed = 2;

    private bool ok = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        manageMovement();

        if (transform.rotation.eulerAngles.z == 360)
            transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void turn(direction dir)
    {
        turnTo(getAngle(dir));
    }

    public void startAt(direction dir)
    {
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, getAngle(dir));
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
    }


    private IEnumerator test()
    {
        for(int i = 0; i < 5; i++)
        {
            turnTo(getAngle(direction.RIGHT));

            yield return new WaitForSeconds(2);

            turnTo(getAngle(direction.UP));

            yield return new WaitForSeconds(2);

            turnTo(getAngle(direction.LEFT));

            yield return new WaitForSeconds(2);

            turnTo(getAngle(direction.UP));

            yield return new WaitForSeconds(2);
        }
    }

    private void turnTo(float angle)
    {
        StartCoroutine(turnToNumerator(angle));
    }

    private IEnumerator turnToNumerator(float angle)
    {
        yield return null;


        int safething = 0;
        float curAngle = transform.rotation.eulerAngles.z;
        float val1 = angle - curAngle;
        float option2 = val1 + ((curAngle > angle) ? 360 : -360);
        float angleStart = ((angle < 180 && curAngle < 180) ? val1 : option2);
        float angleLeft = Mathf.Abs(angleStart);

        while (angleLeft > 0 && safething < 99999999)
        {

            yield return null;


            float amount = angleStart * Time.deltaTime * rotateSpeed;
            angleLeft -= Mathf.Abs(amount);
            transform.Rotate(0, 0, amount);
            rb.velocity = transform.up * speed * Time.fixedDeltaTime;
            safething++;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);

        yield return null;
    }

    private void manageMovement()
    {
        if (!ok)
            return;

        if(!directionUpToDate)
        {
            updateMovement();
        }
    }

    private void updateMovement()
    {
        rb.SetRotation(getAngle(dir));
        directionUpToDate = true;
    }

    private void setGoings(float angleDir)
    {
        rb.SetRotation(angleDir);
    }

    private float getAngle(direction dir)
    {
        switch (dir)
        {
            case direction.RIGHT:
                return 270;
            case direction.LEFT:
                return 90;
        }

        return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            rb.velocity = Vector2.zero;
            ok = false;
            rb.freezeRotation = false;
        }
    }
}

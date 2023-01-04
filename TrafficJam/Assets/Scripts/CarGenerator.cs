using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{

    public enum type
    {
        ONE_TIME_AREA = 0,
        CONTINUOUS_TUNNEL = 1
    }

    public type SpawnType = type.CONTINUOUS_TUNNEL;
    public CarBehaviour.direction dir = CarBehaviour.direction.UP;
    public int amountAtATime = 1;

    public GameObject[] cars;

    private BoxCollider2D range;

    float lastSpawn = 0;
    float spawnInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<BoxCollider2D>();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnType == type.CONTINUOUS_TUNNEL)
        { 
                float lapse = Time.time - lastSpawn;

                if (lapse >= spawnInterval)
                {
                    spawn();
                }
        }
    }

    private void spawn()
    {
        for(int i = 0; i < amountAtATime; i++)
        {
            spawnCar();
        }

        lastSpawn = Time.time;
    }

    private void spawnCar()
    {
        GameObject car = Instantiate(cars[Random.Range(0, cars.Length)]);
        car.GetComponent<CarBehaviour>().startAt(dir);
        car.transform.position = getRandomPos();
        car.SetActive(true); 
    }

    private Vector2 getRandomPos()
    {
        float x = 0;
        float y = 0;

        int toolong = 3;

        do
        {
            x = transform.position.x + Random.Range(-(range.size.x / 2), (range.size.x / 2));
            y = transform.position.y + Random.Range(-(range.size.y / 2), (range.size.y / 2));
            toolong--;

        } while ((Physics2D.OverlapCircle(new Vector2(x, y), 1) != null) && toolong > 0);

        return new Vector2(x, y);

    }


}

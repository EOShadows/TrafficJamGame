using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoads : MonoBehaviour
{
    public GameObject straightPrefab;
    public GameObject turnPrefab;
    public GameObject player;
    public GameObject tilemap;
    public GameObject carcommandPrefab;
    public string direction = "straight";

    public GameObject trainPrefab;
    public GameObject canvas;
    public GameObject trainWarningPrefab;

    public GameSetup gs;
    public Transform work;
    private int roads = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (roads >= gs.end)
            return;

        int roadsBef = roads;

        if (direction == "straight")
        {
            if (player.transform.position.y > transform.position.y - 60f)
            {
                spawnTrain();
                if (Random.Range(1, 10) == 1)
                {

                    if (Random.Range(1, 3) == 2)
                    {
                        GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                        newRoad.GetComponent<CommandCars>().command = CarBehaviour.direction.RIGHT;
                        direction = "right";
                        newRoad.transform.parent = tilemap.transform;
                        transform.position = new Vector3(transform.position.x + 10f, transform.position.y + 10f, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - 10f, transform.position.y + 10f, transform.position.z);
                        GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                        newRoad.transform.Rotate(0f, 0f, -90f);
                        newRoad.GetComponent<CommandCars>().command = CarBehaviour.direction.LEFT;
                        direction = "left";
                        newRoad.transform.parent = tilemap.transform;
                    }
                }
                else
                {
                    GameObject newRoad = Instantiate(straightPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.transform.parent = tilemap.transform;
                    newRoad.GetComponent<CarGenerator>().dir = CarBehaviour.direction.UP;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);

                    roads++;
                }
            }
        }
        else if (direction == "right")
        {
            if (player.transform.position.x > transform.position.x - 60f)
            {
                if (Random.Range(1, 4) == 1)
                {
                    transform.position = new Vector3(transform.position.x + 10f, transform.position.y + 10f, transform.position.z);
                    GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.GetComponent<CommandCars>().command = CarBehaviour.direction.UP;
                    direction = "straight";
                    newRoad.transform.Rotate(0f, 0f, 180f);
                    newRoad.transform.parent = tilemap.transform;
                }
                else
                {
                    GameObject newRoad = Instantiate(straightPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.transform.Rotate(0f, 0f, -90f);
                    newRoad.GetComponent<CarGenerator>().dir = CarBehaviour.direction.RIGHT;
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z);

                    roads++;
                }
            }
        }
        else
        {
            if (player.transform.position.x < transform.position.x + 60f)
            {
                if (Random.Range(1, 4) == 1)
                {
                    GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                    direction = "straight";
                    newRoad.GetComponent<CommandCars>().command = CarBehaviour.direction.UP;
                    newRoad.transform.Rotate(0f, 0f, 90);
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x - 10f, transform.position.y + 10f, transform.position.z);
                }
                else
                {
                    GameObject newRoad = Instantiate(straightPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.transform.Rotate(0f, 0f, 90f);
                    newRoad.GetComponent<CarGenerator>().dir = CarBehaviour.direction.LEFT;
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x - 20f, transform.position.y, transform.position.z);

                    roads++;
                }
            }
        }

        if (roadsBef != roads)
            work.position = transform.position;

        Debug.Log(roads);
    }


    void spawnTrain()
    {
        int rand = Random.Range(1, 10);
        GameObject newTrain = Instantiate(trainPrefab, new Vector3(transform.position.x + rand, transform.position.y, transform.position.z), Quaternion.identity);
        GameObject newTrainWarning = Instantiate(trainWarningPrefab);
        newTrainWarning.transform.SetParent(canvas.transform);
        newTrainWarning.GetComponent<moveWarning>().setCanvas(canvas);
        newTrainWarning.GetComponent<moveWarning>().setTrack(newTrain);
        GameObject newTrain2 = Instantiate(trainPrefab, new Vector3(transform.position.x - rand, transform.position.y, transform.position.z), Quaternion.identity);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoads : MonoBehaviour
{
    public GameObject straightPrefab;
    public GameObject turnPrefab;
    public GameObject player;
    public GameObject tilemap;
    public string direction = "straight";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "straight"){
            if(player.transform.position.y > transform.position.y-60f){
                if(Random.Range(1, 10) == 1){
                    GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                    direction = "right";
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x + 10f, transform.position.y + 10f, transform.position.z);
                }
                else{
                    GameObject newRoad = Instantiate(straightPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y+20f, transform.position.z);
                }
            }
        }
        else if(direction == "right"){
            if(player.transform.position.x > transform.position.x-60f){
                if(Random.Range(1, 3) == 1){
                    transform.position = new Vector3(transform.position.x + 10f, transform.position.y + 10f, transform.position.z);
                    GameObject newRoad = Instantiate(turnPrefab, transform.position, Quaternion.identity) as GameObject;
                    direction = "straight";
                    newRoad.transform.Rotate(0f, 0f, 180f);
                    newRoad.transform.parent = tilemap.transform;
                }
                else{
                    GameObject newRoad = Instantiate(straightPrefab, transform.position, Quaternion.identity) as GameObject;
                    newRoad.transform.Rotate(0f, 0f, -90f);
                    newRoad.transform.parent = tilemap.transform;
                    transform.position = new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTrail : MonoBehaviour
{
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Drift")){
            trail.emitting = true;
        }
        else{
            trail.emitting = false;
        }
    }
}

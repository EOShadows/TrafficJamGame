using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWarning : MonoBehaviour
{
    public GameObject track;
    public GameObject canvas;
    RectTransform CanvasRect;
    RectTransform ourRect;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(track){
            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(track.transform.position);
            Vector2 WorldObject_ScreenPosition=new Vector2(
    ((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),
    ((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f)));
            ourRect.anchoredPosition = new Vector3(WorldObject_ScreenPosition.x, -50);
        }
    }

    public void setTrack(GameObject t){
        track = t;
    }

    public void setCanvas(GameObject c){
        canvas = c;
        CanvasRect = canvas.GetComponent<RectTransform>();
        ourRect = GetComponent<RectTransform>();
        ourRect.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        ourRect.anchoredPosition = new Vector3(0f, -50f);
    }
}

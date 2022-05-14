using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class indicator : MonoBehaviour
{

    public Transform location;
    public Transform player;

    Image panel;
    public float width;
    Transform marker;
    public float markerX;
    float angleToMarker;


    void Start()
    {
        panel = transform.GetComponent<Image>();
        marker = transform.GetChild(0);
        width = panel.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        updateMarker();
    }

    void updateMarker()
    {
        Vector2 direction = new Vector2(location.position.x - player.position.x, location.position.y - player.position.y);
        markerX = Vector2.Angle(player.forward, direction);
        //markerX = map(angleToMarker, 0, 0, 180, width);
        //marker.position = new Vector3(markerX, marker.position.y, marker.position.z);
    }



    public float map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}

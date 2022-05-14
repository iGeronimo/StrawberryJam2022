using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField]
    Vector3 boundary1;
    [SerializeField]
    Vector3 boundary2;
    [SerializeField]
    float dist;
    [SerializeField]
    Vector3 destination;

    public float speed;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        boundary1 = transform.position + transform.GetChild(0).localPosition;
        boundary2 = transform.position + transform.GetChild(1).localPosition;
        destination = boundary1;
        direction = Vector3.Normalize(boundary1 - boundary2);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {     
        dist = (destination - transform.position).magnitude;
        transform.Translate(direction * (speed * Time.deltaTime), Space.World);
        if(dist <= 0.3f)
        {
            changeDirection();
        }
    }

    void changeDirection()
    {
        Debug.Log("change direction");
        if(destination == boundary1)
        {
            destination = boundary2;
            direction = Vector3.Normalize(boundary2 - boundary1);
        } 
        else if(destination == boundary2)
        {
            destination = boundary1;
            direction = Vector3.Normalize(boundary1 - boundary2);
        }
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            collision.gameObject.transform.SetParent(transform);
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            other.transform.SetParent(null);
        }
    }

}

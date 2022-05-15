using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaCollision : MonoBehaviour
{
    public LayerMask lava;
    public Transform winCondition;

    public bool touchingLava = false;
    public Transform lavaCheck;
    public float groundDistance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchingLava = Physics.CheckSphere(lavaCheck.position, groundDistance, lava);
        
        if (touchingLava)
        {
            winCondition.GetComponent<winCondition>().winnable = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(lavaCheck.position, groundDistance);
    }



}

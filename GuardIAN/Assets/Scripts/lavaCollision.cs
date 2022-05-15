using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaCollision : MonoBehaviour
{
    public LayerMask lava;
    public Transform winCondition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.layer == lava)
        {
            Debug.Log("lava");
            winCondition.GetComponent<winCondition>().winnable = false;
        }
    }


}

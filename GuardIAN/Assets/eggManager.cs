using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eggManager : MonoBehaviour
{

    public List<Transform> eggsToBeFound;
    public int oldChildCount;
    public int eggCount = 0;
    public TextMeshProUGUI eggCountText;

    int totalEggs;

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            eggsToBeFound.Add(transform.GetChild(i));
        }
        totalEggs = transform.childCount;
    }


    // Start is called before the first frame update
    void Start()
    {
        eggCountText.text = "eggCount: " + eggCount + "/" + totalEggs;
        oldChildCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldChildCount > transform.childCount)
        {
            eggCount ++;
            eggCountText.text = "eggCount: "+ eggCount + "/" + totalEggs;
            oldChildCount = transform.childCount;
        }
    }
}

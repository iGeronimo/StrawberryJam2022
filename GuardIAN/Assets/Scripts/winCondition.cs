using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class winCondition : MonoBehaviour
{

    public TextMeshProUGUI eggText;
    public TextMeshProUGUI nessieText;

    public TextMeshProUGUI timerText;
    public float totalTime;
    public float currentTime;

    public bool eggCon = false;
    public bool nessieCon = false;
    public bool winnable = true;
    public bool won = false;

    public GameObject gameWonScreen;
    public GameObject gameOverScreen;

    public GameObject nessieInidcator;

    private bool oneTime = true;


    // Start is called before the first frame update
    void Start()
    {
        nessieText.enabled = false;
        gameWonScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        currentTime = totalTime;
        nessieInidcator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        winConCheck();
        timer();
    }


    void winConCheck()
    {
        eggCon = transform.GetChild(0).GetComponent<eggManager>().eggQuestDone;
        if (eggCon)
        {
            markEggConAsDone();
            nessieInidcator.SetActive(true);
        }
        if (nessieCon)
        {
            if (eggCon)
            {
                gameWonScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                nessieText.color = Color.green;
                won = true;
            }else
            {
                nessieCon = false;
            }
            
        }
        if(winnable == false && oneTime)
        {
            FindObjectOfType<AudioManager>().PlaySound("EggSizzle");
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            oneTime = false;
        }
    }

    void markEggConAsDone()  
    {
        eggText.color = Color.green;
        nessieText.enabled = true;
    }


    void timer()
    {
        if (winnable && !won)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "time left: " + Mathf.RoundToInt(currentTime);
            if (currentTime <= 0)
            {
                winnable = false;
                timerText.text = "time left: 0";
            }
           
        }
    }
}
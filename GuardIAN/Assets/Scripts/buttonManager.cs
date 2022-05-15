using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
   

    public void restartGame()
    {
        Debug.Log("new scene pls :(");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}

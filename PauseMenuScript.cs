using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenuDisplay;
    public static bool pauseIn = false;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseFunction();
        }
    }

    public void Test()
    {
        UnityEngine.Debug.Log("Button Works Here!");
    }

    public void PauseFunction()
    {
        if (pauseIn)
        {
            PauseMenuDisplay.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenuDisplay.SetActive(false);
            Time.timeScale = 1f;
        }
        pauseIn = !pauseIn;
    } 
}

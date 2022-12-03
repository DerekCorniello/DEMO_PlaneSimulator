using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public TextMeshProUGUI TargetsText = null;
    public TextMeshProUGUI RocketsText = null;
    public TextMeshProUGUI TargetsTextGameOver = null;
    public TextMeshProUGUI RocketsTextGameOver = null;
    public TextMeshProUGUI WinMessage = null;
    public GameObject WinUI;
    public GameObject PlaneUI;

    public void gameOverFunction(bool winVar, bool crashVar)
    {
        WinUI.SetActive(true);
        PlaneUI.SetActive(false);
        TargetsTextGameOver.text = TargetsText.text;
        RocketsTextGameOver.text = RocketsText.text;

        if (winVar)
        {
            WinMessage.text = "You Won!";
        }

        else
        {
            WinMessage.text = "You Lost!";
        }

        if (!crashVar)
        {
            Time.timeScale = 0f;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void homeScreen()
    {
        SceneManager.LoadScene("Home Scene");
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
}

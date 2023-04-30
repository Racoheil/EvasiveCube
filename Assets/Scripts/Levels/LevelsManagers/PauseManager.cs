using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public static bool isUnBlocked = false;
    public void unBlocked() { isUnBlocked = true; }
    public void pauseButtonHide()
    {
        pauseButton.SetActive(false);
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
    }
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
    }
    public void BackToMenu()
    {

        Debug.Log("Back to menu");
        SceneManager.LoadScene("MainMenu");


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
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
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void slowDown()
    {
        Time.timeScale = 0.5f;
    }
    public void ClosePausePanel()
    {
        Resume();
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void MainMenu()
    {

        Debug.Log("Back to menu");
        SceneManager.LoadScene("MainMenu");


    }
    public void goToNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void restartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
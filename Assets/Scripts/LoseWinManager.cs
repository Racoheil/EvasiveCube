using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinManager : MonoBehaviour
{
    public static LoseWinManager instance;
    public GameObject loseObjects;
    public GameObject winObjects;
    public GameObject timer;
    public GameObject pauseButton;

    void Awake()
    {
        instance = this;
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void playerLose()
    {
        hidePauseButton();
        playerMove.instance.isMove = false;
        Timer.instance.StopTimer();
        timer.SetActive(false);
        loseObjects.SetActive(true);
   
    }
    public void playerWin()
    {
        hidePauseButton();
        playerMove2.instance.isMove = false;

        Timer.instance.StopTimer();
        timer.SetActive(false);
        winObjects.SetActive(true);

      
    }
    void hidePauseButton()
    {
        pauseButton.gameObject.SetActive(false);
    }
    public void restartLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

}

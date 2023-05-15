using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWinManager : MonoBehaviour
{
    public static LoseWinManager instance;
    public GameObject loseObjects;
    public GameObject winObjects;
    public GameObject timer;
    public GameObject pauseButton;

    [SerializeField]bool gameEnded;
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
        if (!gameEnded)
        {
            playerMove2.instance.offMove();
            StartCoroutine(playerLoseCoroutine());
            gameEnded = true;
        }
    }
    public void playerWin()
    {
        if (!gameEnded)
        {
            hidePauseButton();
            playerMove2.instance.offMove();

            Timer.instance.StopTimer();
            timer.SetActive(false);
            winObjects.SetActive(true);
            savePoints();
            gameEnded = true;
        }
    }
    void hidePauseButton()
    {
        pauseButton.gameObject.SetActive(false);
    }
    public void restartLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    IEnumerator playerLoseCoroutine()
    {

        yield return new WaitForSecondsRealtime(1f);
        hidePauseButton();
      //  playerMove2.instance.isMove = false;
        Timer.instance.StopTimer();
        timer.SetActive(false);
        loseObjects.SetActive(true);
        savePoints();

    }
    void savePoints()
    {
        PlayerBalance.instance.showBalance();

        MoneyEarn.instance.topBalance();
        MoneyEarn.instance.hidePoints();
        PlayerBalance.instance.SaveBalance();
    }
}

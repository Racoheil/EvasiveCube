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
    void Awake()
    {
        instance = this;
    }
    
    public void playerLose()
    {
        playerMove.instance.isMove = false;
        ChangeMode.instance.StopCoroutine();
        ChangeMode.instance.changeMode(0);
        Timer.instance.StopTimer();
        timer.SetActive(false);
        loseObjects.SetActive(true);
        BombsGenerate.instance.isGenerateBombs = false;
        playerMove.instance.isCorrect = false;
    }
    public void playerWin()
    {
        playerMove.instance.isMove = false;
        ChangeMode.instance.StopCoroutine();
        ChangeMode.instance.changeMode(0);
        Timer.instance.StopTimer();
        timer.SetActive(false);
        winObjects.SetActive(true);
        BombsGenerate.instance.isGenerateBombs = false;
        playerMove.instance.isCorrect = false;
    }
    public void restartLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

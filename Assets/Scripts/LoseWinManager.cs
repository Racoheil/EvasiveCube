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
        ChangeMode.instance.StopAllCoroutines();
        // ChangeMode.instance.changeMode(0);
        Timer.instance.StopTimer();
        timer.SetActive(false);
        loseObjects.SetActive(true);
        if (ChangeMode.instance.isFirstLevel){ BombsGenerate.instance.isGenerateBombs = false; }
        if (ChangeMode.instance.isSecondLevel) { CellsHeat.instance.isHeat = false; }
        //playerMove.instance.isCorrect = false;
    }
    public void playerWin()
    {
        playerMove2.instance.isMove = false;
        ChangeMode.instance.StopAllCoroutines();
       // ChangeMode.instance.changeMode(0);
        Timer.instance.StopTimer();
        timer.SetActive(false);
        winObjects.SetActive(true);
       
        if (ChangeMode.instance.isFirstLevel) { BombsGenerate.instance.isGenerateBombs = false; }
        if (ChangeMode.instance.isSecondLevel) { CellsHeat.instance.isHeat = false; }
        //playerMove.instance.isCorrect = false;
    }
    public void restartLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

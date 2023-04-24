using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]Image timerBar;
    [SerializeField] float maxTime = 60f;
    float timeLeft;
    int time = 0;
    [SerializeField] Text score;
    public static Timer instance;
    public bool isStop = false;
    void Awake()
    {
        instance = this;
    }
    public int getTime()
    {
        return time;
    }
   void Start()

    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        StartCoroutine("timerCoroutine");
        
    }
    public void StopTimer()
    {
        StopCoroutine(timerCoroutine());
        isStop = true;
    }
   
    IEnumerator timerCoroutine()
    {
        isStop = false;
        while(timerBar.fillAmount>=0)
        {
            score.text = time.ToString();
            timerBar.fillAmount -= 1/maxTime;
           
            yield return new WaitForSeconds(1f);
            //   Debug.Log("Time: "+time);
            score.text = time.ToString();
            time++;
            if (time == maxTime) { LoseWinManager.instance.playerWin(); isStop = true; }
        }
       
       
    }
}

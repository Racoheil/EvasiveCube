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
    void Awake()
    {
        instance = this;
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
    }
   
    IEnumerator timerCoroutine()
    {
        while(timerBar.fillAmount>=0)
        {
            score.text = time.ToString();
            timerBar.fillAmount -= 1/maxTime;
           
            yield return new WaitForSeconds(1f);
            //   Debug.Log("Time: "+time);
            score.text = time.ToString();
            time++;
            if (time == 60) { LoseWinManager.instance.playerWin(); }
        }
       
       
    }
}

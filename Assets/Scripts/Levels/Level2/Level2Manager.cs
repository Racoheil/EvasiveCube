using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : ILevelManager
{
    [SerializeField] float timeStep=5f;
   
    [SerializeField] int playerSpeedStep=3;
    [SerializeField] bool isChange;
    
    
    void Start()

    {
        Timer.instance.setHoldWin(true);
        isChange = true;
        StartCoroutine("changeModeCoroutine");
        Application.targetFrameRate = 40;
    }
    public void StopTimer()
    {
        StopCoroutine(changeModeCoroutine());
    }
  
    IEnumerator changeModeCoroutine()
    {
        while (isChange)
        {

            
            yield return new WaitForSeconds(timeStep);
            //if(playerMove2.instance.speed<)
            playerMove2.instance.addSpeed(playerSpeedStep);
            CellsHeat.instance.addWaitTime(-0.01f);
            Debug.Log("Mode is changed");
            Debug.Log("Time is " + Timer.instance.getTime());
            
        }


    }
}

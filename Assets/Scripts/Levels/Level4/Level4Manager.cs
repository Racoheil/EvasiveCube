using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Manager : MonoBehaviour
{
    [SerializeField] float timeStep = 5f;

    [SerializeField] int playerSpeedStep = 2;
    [SerializeField] bool isChange;


    void Start()

    {
        Application.targetFrameRate = 40;
        Timer.instance.setHoldWin(true);
        isChange = true;
        StartCoroutine("changeModeCoroutine");


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
           // CellsHeat.instance.addWaitTime(-0.01f);
            Debug.Log("Mode is changed");
            Debug.Log("Time is " + Timer.instance.getTime());

        }


    }
}
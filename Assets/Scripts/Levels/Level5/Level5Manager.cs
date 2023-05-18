using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Manager : MonoBehaviour
{
    bool isChange;
    float timeStep = 5f;
    float knifeSpdStep = 0.01f;
    int playerSpdStep =2;
    private void Start()
    {
        isChange = true;
        Timer.instance.setHoldWin(true);
        StartCoroutine(changeModeCoroutine());
        Application.targetFrameRate = 40;

    }
    IEnumerator changeModeCoroutine()
    {
        while (isChange)
        {
            yield return new WaitForSeconds(timeStep);
            playerMove2.instance.addSpeed(playerSpdStep);
            KnifeControl.instance.addSpeed(knifeSpdStep);
        }
    }
}

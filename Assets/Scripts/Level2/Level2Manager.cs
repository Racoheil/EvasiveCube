using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField] float timeStep=5f;
   
    [SerializeField] int playerSpeedStep=3;
    [SerializeField] bool isChange;
    
    
    void Start()

    {
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
            playerMove2.instance.changeSpeed(playerSpeedStep);
           
            Debug.Log("Mode is changed");
            Debug.Log("Time is " + Timer.instance.getTime());
            
        }


    }
}

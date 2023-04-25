using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] float timeStep=5f;
   [SerializeField] int bombDragStep=3;
    [SerializeField] int playerSpeedStep=3;
    [SerializeField] bool isChange;
    [SerializeField] float timeSpawnAdd=0.05f;
    
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
            BombsGenerate2.instance.reduceBombDrag(bombDragStep);
            //Debug.Log("Mode is changed");
            Debug.Log("Time is " + Timer.instance.getTime());
            if (Timer.instance.getTime() > 10)
            {
                
                BombsGenerate2.instance.addTimeBombsSpawn(-timeSpawnAdd);
                Debug.Log("SpawnTimeChanged on" +BombsGenerate2.instance.getSpawnWait());
            }
        }


    }
}

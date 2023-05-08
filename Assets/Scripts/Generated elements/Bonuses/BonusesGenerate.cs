using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BonusesGenerate : MonoBehaviour
{

    [SerializeField] bool isGenerateBonuses = true;
    [SerializeField] GameObject[] bonuses;
    float height;
    [SerializeField] Vector3 bonusPos;
    [SerializeField] int spawnWait = 5;
    [SerializeField] GameObject[] cells;
 
   
    
    
    void Start()
    {
      
       
        StartCoroutine(bonusesGenerate());
    }
   
    private IEnumerator bonusesGenerate()
    {
        while (isGenerateBonuses==true)
        {
            yield return new WaitForSeconds(spawnWait);
           
            spawnBonus(0);
            spawnBonus(1);
        }


    }
   
    void spawnBonus(int bonusNum)
    {
        
        bonusPos = cells[UnityEngine.Random.Range(0, cells.Length)].transform.position;
        bonusPos.y = bonuses[bonusNum].transform.position.y;
        Instantiate(bonuses[bonusNum], bonusPos, Quaternion.identity);
    }
}

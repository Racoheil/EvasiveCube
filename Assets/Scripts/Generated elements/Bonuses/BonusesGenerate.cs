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
  
    [SerializeField] BombsGenerate bombsGenerate;
   
    void Awake()
    {
     
    }
    void Start()
    {
      
       
        StartCoroutine(bonusesGenerate());
    }
   
    private IEnumerator bonusesGenerate()
    {
        while (isGenerateBonuses==true)
        {
            yield return new WaitForSeconds(spawnWait);
            System.Random rand = new System.Random();
            int bonusNum = rand.Next(0, 2);
            bonusPos = BombsGenerate.instance.cellsPositions[UnityEngine.Random.Range(0,BombsGenerate.instance.cellsPositions.Count)];
            bonusPos.y = bonuses[bonusNum].transform.position.y;
            Instantiate(bonuses[bonusNum], bonusPos, Quaternion.identity);
        }


    }
   

}

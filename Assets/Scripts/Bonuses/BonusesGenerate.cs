using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BonusesGenerate : MonoBehaviour
{
    [SerializeField] GameObject medicine;
    [SerializeField] GameObject armor;
    [SerializeField] bool isGenerateBonuses = true;
    [SerializeField] GameObject[] bonuses;
    float height;
    [SerializeField] Vector3 bonusPos;
    [SerializeField] int spawnWait = 5;
   // [SerializeField] public List<Vector3> cellsPositions;
   // [SerializeField] public GameObject[] cells;
    //public void BonusesGenerate()
    //{
    [SerializeField] BombsGenerate bombsGenerate;
    //}
    void Awake()
    {
       // cellsPositions = bombsGenerate.cellsPositions;
    }
    void Start()
    {
       // bombsGenerate.fillList();
        //bonuses = new GameObject[2];
        //bonuses[0] = medicine;
        //bonuses[1] = armor;
       // 
        StartCoroutine(bonusesGenerate());
    }
    //public void StopGenerate()
    //{
    //    Coroutine(StopAllCoroutines());
    //}
    //IEnumerable BonusesGenerate
    //{

    //}
    private IEnumerator bonusesGenerate()
    {
        //int i = 0;
        while (isGenerateBonuses==true)
        {
            yield return new WaitForSeconds(spawnWait);
            //Debug.Log("111");
            //if (BombsGenerate.instance.cellsPositions.Count < 1)
            //{
            //    isGenerateBonuses = false;
            //    StopCoroutine(BonusesGenerate());
            //}

            System.Random rand = new System.Random();
            int bonusNum = rand.Next(0, 2);
           

            //Debug.Log("Рандомное число это " + bonusNum);
            //
           bonusPos = BombsGenerate.instance.cellsPositions[UnityEngine.Random.Range(0,BombsGenerate.instance.cellsPositions.Count)];
            //bonusPos = bombsGenerate.cellsPositions[0];
            //bonusPos = Vector3.zero;
            bonusPos.y = bonuses[bonusNum].transform.position.y;
            //  Instantiate(medicine, bonusPos, Quaternion.identity);
            Instantiate(bonuses[bonusNum], bonusPos, Quaternion.identity);
          //  Instantiate(bonuses[bonusNum], bonusPos, Quaternion.Euler(bonuses[bonusNum].transform.position));
            // i++;
            

        }


    }
   

}
